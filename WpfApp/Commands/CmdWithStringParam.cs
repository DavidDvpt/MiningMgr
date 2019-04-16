using System;
using System.Windows.Input;

namespace WpfApp.Commands
{
    // Commande avec parametre string
    public class CmdWithStringParam<T> : ICommand
    {
        // Methode cible à executer
        Action<T> _TargetExecuteMethod;

        // Methode qui valide l'execution de la méthode à executer
        Func<T, bool> _TargetCanExecuteMethod;

        // Constructeur avec la methode à éxécuter simple (CanExecute = true par defaut)
        public CmdWithStringParam(Action<T> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        // Constructeur avec la methode à éxécuter et la méthode de validation
        public CmdWithStringParam(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }



        // evenement qui relance la methode CanExecute
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members
        // Methode autorisant l'execution de la méthode de commande
        bool ICommand.CanExecute(object parameter)
        {
            // Si il y a une methode de validation de l'execution
            if (_TargetCanExecuteMethod != null)
            {
                T tparm = (T)parameter;
                return _TargetCanExecuteMethod(tparm);
            }

            // Execution de la methode de commande car true par defaut
            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        // Beware - should use weak references if command instance lifetime is
        //longer than lifetime of UI objects that get hooked up to command

        // Prism commands solve this in their implementation 

        // evenement qui relance la methode CanExecute
        public event EventHandler CanExecuteChanged = delegate { };

        // Methode qui lance l'execution de la methode de commande
        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod((T)parameter);
            }
        }

        #endregion
    }
}
