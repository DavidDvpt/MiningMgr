using System.Collections.Generic;

namespace ViewModels.BaseClasses
{
    /// <summary>
    /// Quand le VueModel est fermé, les vues associées doivent fermer aussi
    /// </summary>
    /// <param name="dialogResult"></param>
    public delegate void ViewModelClosingEventHandler(bool? dialogResult);

    /// <summary>
    /// Quand un ViewModel pre-exisant est activé, la vue doit s'activer aussi
    /// </summary>
    public delegate void ViewModelActivatingEventHandler();

    /// <summary>
    /// Classe de base pour tous les ViewModel
    /// </summary>
    public class BaseViewModel : BindableBase
    {
        public event ViewModelClosingEventHandler ViewModelClosing;
        public event ViewModelActivatingEventHandler ViewModelActivating;

        /// <summary>
        /// Conservez une liste de tous les enfants ViewModels afin que nous puissions
        /// les supprimer en toute sécurité lorsque ce ViewModel est fermé.
        /// </summary>
        public List<BaseViewModel> ChildViewModels { get; private set; } = new List<BaseViewModel>();

        #region Propriétés bindables

        public BaseViewData ViewData
        {
            get { return GetValue(() => ViewData); }
            set
            {
                if (ViewData != value)
                {
                    SetValue(() => ViewData, value);
                }
            }
        }

        /// <summary>
        /// Si le viewModel veut faite quelque chose il a besoin du controller
        /// </summary>
        public IController Controller { get; set; }

        #endregion

        #region Constructeurs

        /// <summary>
        /// un ViewModel a besoin d'un controller
        /// </summary>
        /// <param name="controller"></param>
        public BaseViewModel(IController controller)
        {
            Controller = controller;
        }

        /// <summary>
        /// Créer le modèle de vue avec un contrôleur et un FrameworkElement(View) injecté
        /// Notez que nous ne conservons pas de référence à la vue - définissons simplement son contexte de données et
        /// l'abonne à nos événements d'activation et de clôture ...
        /// Bien sûr, cela signifie qu'il y a des références - qui doivent être supprimées lorsque la vue se ferme,
        /// qui est gérée dans BaseView
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="view"></param>
        public BaseViewModel(IController controller, IView view)
            : this(controller)
        {
            if (view != null)
            {
                view.DataContext = this;
                ViewModelClosing += view.ViewModelClosingHandler;
                ViewModelActivating += view.ViewModelActivatingHandler;
            }
        }

        #endregion

        #region Methodes Publiques

        public void CloseViewModel(bool? dialogResult)
        {
            // desenregistre ce viewModel de messenger
            Controller.Messenger.DeRegister(this);
            if (ViewModelClosing != null)
            {
                ViewModelClosing(dialogResult);
            }

            // ferme tous les viewModel enfants
            foreach (var childViewModel in ChildViewModels)
            {
                childViewModel.CloseViewModel(dialogResult);
            }
        }

        public void ActivateViewModel()
        {
            if (ViewModelActivating != null)
            {
                ViewModelActivating();
            }
        }
        #endregion

    }
}
