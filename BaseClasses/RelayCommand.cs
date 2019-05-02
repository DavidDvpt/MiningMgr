using System;
using System.Windows.Input;

namespace BaseClasses
{
    // Commande avec parametre string
    public class RelayCommand : ICommand
    {
        #region Champs
        
        readonly Action<object> _execute; // Methode cible à executer   
        readonly Predicate<object> _canExecute; // Methode qui valide l'execution de la méthode à executer

        #endregion

        #region Constructeurs
        
        public RelayCommand(Action<object> execute) // renvoi sur le 2e constructeur avec canExecute = null
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute) // Constructeur avec la methode à éxécuter et la méthode de validation
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        // evenement qui relance la methode CanExecute
        //public void RaiseCanExecuteChanged()
        //{
        //    CanExecuteChanged(this, EventArgs.Empty);
        //}

        #region ICommand Members      

        public bool CanExecute(object parameter) // Methode autorisant l'execution de la méthode de commande
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        // Beware - should use weak references if command instance lifetime is
        //longer than lifetime of UI objects that get hooked up to command

        // Prism commands solve this in their implementation 
       
        public event EventHandler CanExecuteChanged // evenement qui relance la methode CanExecute
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Methode qui lance l'execution de la methode de commande
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion
    }
}
