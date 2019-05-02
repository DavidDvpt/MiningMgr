using BaseClasses;

namespace ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private IMenuController MenuController => (IMenuController)Controller;

        public MenuViewModel(IController controller)
            : base(controller)
        {
        }

        public MenuViewModel(IController controller, IView view)
            : base(controller, view)
        {
        }

        #region Commands

        public RelayCommand FinderMgr => new RelayCommand(x => { Controller.Messenger.NotifyColleagues(MessageTypes.MSG_COMMAND_AFFICHAGE_FINDERMGR); });

        #endregion

        #region Execute Command

        #endregion
    }
}
