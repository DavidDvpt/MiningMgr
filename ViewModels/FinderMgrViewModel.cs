using BaseClasses;
using System;

namespace ViewModels
{
    public class FinderMgrViewModel : GeneralMgrViewModel
    {
        public FinderMgrViewModel(IController controller) : base(controller)
        {
        }

        public FinderMgrViewModel(IController controller, IView view) : base(controller, view)
        {
            controller.Messenger.Register(MessageTypes.MSG_FINDER_MODIFIED_ADDED_OR_SAVED, new Action<Message>(RefreshList));
            RefreshList();
        }

        public IFinderMgrController FinderController => (IFinderMgrController)Controller;

        #region Affichage des colonns du Datagrid

        public bool NomVisibility => true;
        public bool ValueVisibility => true;
        public bool IsLimitedVisibility => true;
        public bool DecayVisibility => true;
        public bool CodeVisibility => true;
        public bool DetphVisibility => true;
        public bool RangeVisibility => true;
        public bool UsePerMinVisibility => true;
        public bool BasePecSearchVisibility => true;

        #endregion

        #region Execute Command

        public override void CreateExecute(Message message)
        {
            EditViewModel = FinderController.GetFinderEditViewModel(this);
        }

        public override void SubmitExecute(object param)
        {
            throw new NotImplementedException();
        }

        public override void UpdateExecute(Message message)
        {
            EditViewModel = FinderController.GetFinderEditViewModel(this, SelectedItem);
        }

        #endregion

        protected override void RefreshList()
        {
            ViewData = FinderController.GetFinderListViewData("");
        }

        protected override void RefreshList(Message message)
        {
            RefreshList();
            message.HandledStatus = MessageHandledStatus.HandledContinue;
        }
    }
}
