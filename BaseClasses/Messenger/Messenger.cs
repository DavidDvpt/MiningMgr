using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace BaseClasses
{
    /// <summary>
    /// Fournit une messagerie faiblement couplée entre
    /// divers objets collègues.Toutes les références aux objets
    /// sont stockés faiblement, pour éviter les fuites de mémoire.
    /// Basé sur (volé!) La classe MVVMFoundation Messenger - mais modifié pour utiliser une énumération plutôt qu'une chaîne
    /// </summary>
    public class Messenger
	{
		static readonly Messenger instance = new Messenger();

		#region Constructeur

		/// <summary>
		/// Constructeur privé pour ce singleton - utilise Messenger.Instance
		/// </summary>
		private Messenger()
		{
		}

        #endregion

        #region Propriétés publiques

        public static Messenger Instance => instance;

        #endregion

        #region Enregistrement

        /// <summary>
        /// Enregistre une méthode call-back, sans paramètre, à appeler lorsqu'un message spécifique est diffusé.
        /// </summary>
        /// <param name="message">Type du message.(enum)</param>
        /// <param name="callback">Méthode à appeler lorsque le message est diffusé.</param>
        public void Register(MessageTypes message, Action callback)
		{
			this.Register(message, callback, null);
		}

        /// <summary>
        /// Enregistre une méthode ce call-back, avec un paramètre, à appeler lorsqu'un message spécifique est diffusé.
		/// </summary>
		/// <param name="message">Type du message.(enum)</param>
		/// <param name="callback">Méthode à appeler lorsque le message est diffusé.</param>
		public void Register<T>(MessageTypes message, Action<T> callback)
		{
			this.Register(message, callback, typeof(T));
		}

        /// <summary>
        /// Methode appelée par les 2 autres methodes d'enregistrement (séparation de la methode et du prametre)
        /// </summary>
        /// <param name="message"> message d'inscription</param>
        /// <param name="callback"> methode de call-back à appeler lorsque le message est diffusé</param>
        /// <param name="parameterType"> parametre de la méthode</param>
		void Register(MessageTypes message, Delegate callback, Type parameterType)
		{
			// Si la méthode délégué est nulle on lance une erreur
			if (callback == null)
				throw new ArgumentNullException("callback");

			// Verification si le parametre correspond bien au message
			this.VerifyParameterType(message, parameterType);

			// Ajout du message à la liste des messages enregistrés (target = instance de la classe à laquelle appartient la methode) (Method = methode sans le parametre)
			_messageToActionsMap.AddAction(message, callback.Target, callback.Method, parameterType);
		}

        /// <summary>
        /// Lorsque votre classe écoute un message avec une méthode particulière, la méthode DeRegister
        /// supprime votre delagate de la collection - pour que cet auditeur particulier ne reçoive pas ce message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callback"></param>
        public void DeRegister(MessageTypes message, Delegate callback)
		{
			_messageToActionsMap.RemoveAction(message, callback.Target, callback.Method);
		}

        /// <summary>
        /// Lorsque votre classe écoute un message avec une méthode particulière, la méthode DeRegister
        /// supprime tous les delagate de la collection.
        /// Doit être appelé à la fermeture d’un ViewModel pour s’assurer que les objets collectés non-Garbage ne continuent pas.
        /// à recevoir des messages
        /// </summary>
        /// <param name="callback"></param>
        public void DeRegister(object target)
		{
			_messageToActionsMap.RemoveActions(target);
		}

		[Conditional("DEBUG")]
		void VerifyParameterType(MessageTypes message, Type parameterType)
		{
			Type previouslyRegisteredParameterType = null;
			//si le message est enregistré
			if (_messageToActionsMap.TryGetParameterType(message, out previouslyRegisteredParameterType))
			{
				// si le param à verifier et le param trouvé ne sont pas nul
				if (previouslyRegisteredParameterType != null && parameterType != null)
				{
					// On verifie si les 2 sont parametres sont egaux
					// si ils sont differents, on declanche une erreur
					if (!previouslyRegisteredParameterType.Equals(parameterType))
						throw new InvalidOperationException(string.Format(
                            "Le type de paramètre de l'action enregistrée est incompatible avec les actions précédemment enregistrées pour le message '{0}'.\nExpected: {1}\nAdding: {2}",
							message,
							previouslyRegisteredParameterType.FullName,
							parameterType.FullName));
				}
				else
				{
					// Si un des 2 seulement est nul, on declenche une erreur d'incohérence
					if (previouslyRegisteredParameterType != parameterType)
					{
						throw new TargetParameterCountException(string.Format(
                            "L'action enregistrée a un certain nombre de paramètres incohérents avec les actions précédemment enregistrées pour le message. \"{0}\".\nExpected: {1}\nAdding: {2}",
							message,
							previouslyRegisteredParameterType == null ? 0 : 1,
							parameterType == null ? 0 : 1));
					}
				}
			}
		}

        #endregion

        #region NotifyColleagues

        /// <summary>
        /// Notifie tous les partis enregistrés qu'un message est en cours de diffusion.
        /// </summary>
        /// <param name="messageType">Message à diffuser.</param>
        /// <param name="parameter">paramettre à passer avec le message.</param>
        public NotificationResult NotifyColleagues(MessageTypes messageType, object parameter)
		{
			//if (String.IsNullOrEmpty(message))
			//    throw new ArgumentException("'message' cannot be null or empty.");
			NotificationResult result = NotificationResult.MessageNotRegistered;

			Type registeredParameterType;
			// le parametre ne doit pas être nul
			if (_messageToActionsMap.TryGetParameterType(messageType, out registeredParameterType))
			{
				if (registeredParameterType == null)
					throw new TargetParameterCountException(string.Format("Impossible de transmettre un paramètre avec un message '{0}'. l'action enregistree(s) ne demande aucun parametre.", messageType));
			}

			// Récupération de toutes les actions enregistrés pour ce message
			var actions = _messageToActionsMap.GetActions(messageType);
			
			// si il existe des actions, on les traite
			if (actions != null)
			{
				Message message = new Message(messageType)
				{
					HandledStatus = MessageHandledStatus.NotHandled,
					Payload = parameter
				};

				foreach (var action in actions)
				{
					Invoke(message, action);
				}

				switch (message.HandledStatus)
				{
					case MessageHandledStatus.NotHandled:
						result = NotificationResult.MessageRegisteredNotHandled;
						break;
					case MessageHandledStatus.HandledContinue:
						result = NotificationResult.MessageHandled;
						break;
					case MessageHandledStatus.HandledCompleted:
						result = NotificationResult.MessageHandled;
						break;
					case MessageHandledStatus.NotHandledAbort:
						result = NotificationResult.MessageAborted;
						break;
					default:
						break;
				}

			}
			return result;

		}
		
		private void Invoke(Message message, Delegate method)
		{
			if (message.HandledStatus == MessageHandledStatus.HandledContinue || message.HandledStatus == MessageHandledStatus.NotHandled)
			{
				// Les methodes enregistrées doivent avoir "Message" en parametre (qui contient le parametre de la methode)
				// il faut donc 2 signatures differentes, avec et sans "Message" en parametre
				method.DynamicInvoke(message);
			}
		}
        /// <summary>
        /// Notifie tous les partis enregistrés qu'un message est en cours de diffusion.
        /// </summary>
        /// <param name="messageType">The message to broadcast.</param>
        public void NotifyColleagues(MessageTypes messageType)
		{
			//if (String.IsNullOrEmpty(message))
			//    throw new ArgumentException("'message' cannot be null or empty.");

			Type registeredParameterType;
			if (_messageToActionsMap.TryGetParameterType(messageType, out registeredParameterType))
			{
				if (registeredParameterType != null)
					throw new TargetParameterCountException(string.Format("Must pass a parameter of type {0} with this message. Registered action(s) expect it.", registeredParameterType.FullName));
			}

			var actions = _messageToActionsMap.GetActions(messageType);
			if (actions != null)
			{
				// actions.ForEach(action => action.DynamicInvoke());

				foreach (var action in actions)
				{
					action.DynamicInvoke();
				}
			}
		}

        public bool FindAnyRegister(MessageTypes messageType)
        {
            if (_messageToActionsMap.GetActions(messageType) == null)
            {
                //if (_messageToActionsMap.GetActions(messageType).Count() == 0)
                //{
                    return true;
                //}
            }
            return false;
        }

		#endregion 

		#region MessageToActionsMap [nested class]

		/// <summary>
		/// This class is an implementation detail of the Messenger class.
		/// </summary>
		private class MessageToActionsMap
		{
			#region Constructor

			internal MessageToActionsMap()
			{
			}

			#endregion // Constructor

			#region AddAction

			/// <summary>
			/// Ajoute une action à la liste.
			/// </summary>
			/// <param name="message">The message to register.</param>
			/// <param name="target">The target object to invoke, or null.</param>
			/// <param name="method">The method to invoke.</param>
			/// <param name="actionType">The type of the Action delegate.</param>
			internal void AddAction(MessageTypes message, object target, MethodInfo method, Type actionType)
			{
				//if (message == null)
				//    throw new ArgumentNullException("message");

				if (method == null)
					throw new ArgumentNullException("method");

				lock (_map)
				{
					if (!_map.ContainsKey(message))
						_map[message] = new List<WeakAction>();

					_map[message].Add(new WeakAction(target, method, actionType));
				}
			}

			/// <summary>
			/// Removes an action from the list, for the message type, object and method specified
			/// </summary>
			/// <param name="message"></param>
			/// <param name="target"></param>
			/// <param name="method"></param>
			/// <param name="actionType"></param>
			internal void RemoveAction(MessageTypes message, object target, MethodInfo method)
			{
				lock (_map)
				{
					List<WeakAction> wr;
					if (_map.TryGetValue(message, out wr))
					{
						wr.RemoveAll(wa => target == wa.TargetRef.Target && method == wa.Method);

						if (wr.Count == 0)
							_map.Remove(message);
					}
				}
			}

			/// <summary>
			/// Remove all actions from the list for the given target object
			/// Used when 'closing' a viewmodel
			/// </summary>
			/// <param name="target"></param>
			internal void RemoveActions(object target)
			{
				lock (_map)
				{
					ICollection<List<WeakAction>> x = _map.Values;
					foreach (var item in x)
					{
						item.RemoveAll(wa => target == wa.TargetRef.Target);
					}

				}
			}

			#endregion // AddAction

			#region GetActions

			/// <summary>
			/// Gets the list of actions to be invoked for the specified message
			/// </summary>
			/// <param name="message">The message to get the actions for</param>
			/// <returns>Returns a list of actions that are registered to the specified message</returns>
			internal List<Delegate> GetActions(MessageTypes message)
			{
				//if (message == null)
				//    throw new ArgumentNullException("message");

				List<Delegate> actions;
				lock (_map)
				{
					if (!_map.ContainsKey(message))
						return null;

					List<WeakAction> weakActions = _map[message];
					actions = new List<Delegate>(weakActions.Count);
					for (int i = weakActions.Count - 1; i > -1; --i)
					{
						WeakAction weakAction = weakActions[i];
						if (weakAction == null)
							continue;

						Delegate action = weakAction.CreateAction();
						if (action != null)
						{
							actions.Add(action);
						}
						else
						{
							// The target object is dead, so get rid of the weak action.
							weakActions.Remove(weakAction);
						}
					}

					// Delete the list from the map if it is now empty.
					if (weakActions.Count == 0)
						_map.Remove(message);
				}

				// Reverse the list to ensure the callbacks are invoked in the order they were registered.
				actions.Reverse();

				return actions;
			}

			#endregion // GetActions

			#region TryGetParameterType

			/// <summary>
			/// Get the parameter type of the actions registered for the specified message.
			/// </summary>
			/// <param name="message">The message to check for actions.</param>
			/// <param name="parameterType">
			/// When this method returns, contains the type for parameters 
			/// for the registered actions associated with the specified message, if any; otherwise, null.
			/// This will also be null if the registered actions have no parameters.
			/// This parameter is passed uninitialized.
			/// </param>
			/// <returns>true if any actions were registered for the message</returns>
			internal bool TryGetParameterType(MessageTypes message, out Type parameterType)
			{
				//if (message == null)
				//    throw new ArgumentNullException("message");

				parameterType = null;
				List<WeakAction> weakActions;
				lock (_map)
				{
					if (!_map.TryGetValue(message, out weakActions) || weakActions.Count == 0)
						return false;
				}
				parameterType = weakActions[0].ParameterType;
				return true;
			}

			#endregion // TryGetParameterType

			#region Fields

			// Stores a hash where the key is the message and the value is the list of callbacks to invoke.
			readonly Dictionary<MessageTypes, List<WeakAction>> _map = new Dictionary<MessageTypes, List<WeakAction>>();

			#endregion // Fields
		}

		#endregion // MessageToActionsMap [nested class]

		#region WeakAction [nested class]

		/// <summary>
		/// This class is an implementation detail of the MessageToActionsMap class.
		/// </summary>
		private class WeakAction
		{
			#region Constructor

			/// <summary>
			/// Constructs a WeakAction.
			/// </summary>
			/// <param name="target">The object on which the target method is invoked, or null if the method is static.</param>
			/// <param name="method">The MethodInfo used to create the Action.</param>
			/// <param name="parameterType">The type of parameter to be passed to the action. Pass null if there is no parameter.</param>
			internal WeakAction(object target, MethodInfo method, Type parameterType)
			{
				if (target == null)
				{
					_targetRef = null;
				}
				else
				{
					_targetRef = new WeakReference(target);
				}

				_method = method;

				this.ParameterType = parameterType;

				if (parameterType == null)
				{
					_delegateType = typeof(Action);
				}
				else
				{
					_delegateType = typeof(Action<>).MakeGenericType(parameterType);
				}
			}

			#endregion // Constructor

			#region CreateAction

			/// <summary>
			/// Creates a "throw away" delegate to invoke the method on the target, or null if the target object is dead.
			/// </summary>
			internal Delegate CreateAction()
			{
				// Rehydrate into a real Action object, so that the method can be invoked.
				if (_targetRef == null)
				{
					return Delegate.CreateDelegate(_delegateType, _method);
				}
				else
				{
					try
					{
						object target = _targetRef.Target;
						if (target != null)
							return Delegate.CreateDelegate(_delegateType, target, _method);
					}
					catch
					{
					}
				}

				return null;
			}

			#endregion // CreateAction

			#region Fields

			internal readonly Type ParameterType;

			readonly Type _delegateType;
			readonly MethodInfo _method;
			readonly WeakReference _targetRef;

			#endregion // Fields
			public WeakReference TargetRef
			{
				get
				{
					return _targetRef;
				}
			}
			public MethodInfo Method
			{
				get
				{
					return _method;
				}
			}

		}
		#endregion // WeakAction [nested class]

		#region Fields

		readonly MessageToActionsMap _messageToActionsMap = new MessageToActionsMap();

		#endregion // Fields

	}
}
