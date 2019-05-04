using BaseClasses;
using System;

namespace ViewModels
{
    public class FinderEditViewModel : BaseViewModel
    {
        protected IFinderMgrController FinderEditController => (IFinderMgrController)Controller;

        public FinderEditViewModel(IController controller) : base(controller)
        {
        }

        public FinderEditViewModel(IController controller, IView view) : base(controller, view)
        {
            FinderEditController.Messenger.Register(MessageTypes.MSG_ITEM_SELECTED_FOR_EDIT, new Action<Message>(HandleCustomerSelectedForEditMessage));
        }

        private void HandleCustomerSelectedForEditMessage(Message message)
        {

        }
    }
}
