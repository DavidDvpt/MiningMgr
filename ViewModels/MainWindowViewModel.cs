using BaseClasses;

namespace ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IMainWindowController MainWindowController => (IMainWindowController)Controller;

        #region Constructeurs

        public MainWindowViewModel(IController controller)
            : base(controller)
        {
        }

        public MainWindowViewModel(IController controller, IView view)
            : base(controller, view)
        {
            SetMenu();
            SetStatus();
            NavigationRegister();
        }

        private void NavigationRegister()
        {
            Controller.Messenger.Register(MessageTypes.MSG_COMMAND_AFFICHAGE_FINDERMGR, ShowViewFinderMgr);
        }

        #endregion

        #region Proprietes publiques

        public BaseViewModel MenuViewModel
        {
            get { return GetValue(() => MenuViewModel); }
            private set
            {
                if (MenuViewModel != value)
                {
                    SetValue(() => MenuViewModel, value);
                }
            }
        }

        public BaseViewModel StatusViewModel
        {
            get { return GetValue(() => StatusViewModel); }
            private set
            {
                if (StatusViewModel != value)
                {
                    SetValue(() => StatusViewModel, value);
                }
            }
        }

        public BaseViewModel CurrentViewModel
        {
            get { return GetValue(() => CurrentViewModel); }
            set
            {
                if (CurrentViewModel != value)
                {
                    SetValue(() => CurrentViewModel, value);
                }
            }
        }

        #endregion

        #region Navigation

        private void ShowViewFinderMgr()
        {
            CurrentViewModel = MainWindowController.ShowFinderMgrViewModel();
        }

        #endregion

        #region methodes privées

        private void SetMenu()
        {
            MenuViewModel = MainWindowController.ShowViewMenu();
        }

        private void SetStatus()
        {
            StatusViewModel = MainWindowController.ShowViewStatus();
        }

        #endregion
    }
}
