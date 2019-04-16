using System;
using System.Windows.Input;

namespace WpfApp
{
    public class CommandWithoutParam : ICommand
    {
        Action _TargetExecuteMethod; // methode "execute"
        Func<bool> _TargetCanExecuteMethod; // methode "canExecute"

        //constructeur sans "canExecute" donc true par defaut
        public CommandWithoutParam(Action executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        //constructeur avec "canExecute"
        public CommandWithoutParam(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        // methode de mise à jour des etats de "can"execute"
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod();
            }
        }
    }
}
