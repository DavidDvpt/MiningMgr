using BaseClasses;
using System;

namespace ViewModels
{
    public abstract class GeneralMgrViewModel : BaseViewModel
    {
        public GeneralMgrViewModel(IController controller) : this(controller, null)
        {
        }

        public GeneralMgrViewModel(IController controller, IView view) : base(controller, view)
        {
            controller.Messenger.Register(MessageTypes.MSG_FINDER_MODIFIED_ADDED_OR_SAVED, new Action<Message>(RefreshList));

            controller.Messenger.Register(MessageTypes.MSG_COMMAND_SELECTED_FOR_UPDATE, new Action<Message>(UpdateExecute));
            controller.Messenger.Register(MessageTypes.MSG_COMMAND_SELECTED_FOR_CREATE, new Action<Message>(CreateExecute));

            UpdateCommand = new RelayCommand(x => Controller.Messenger.NotifyColleagues(MessageTypes.MSG_COMMAND_SELECTED_FOR_UPDATE, x), UpdateCanExecute);
            CreateCommand = new RelayCommand(x => Controller.Messenger.NotifyColleagues(MessageTypes.MSG_COMMAND_SELECTED_FOR_CREATE, x), CreateCanExecute);
            SubmitCommand = new RelayCommand(x => Controller.Messenger.NotifyColleagues(MessageTypes.MSG_COMMAND_AFFICHAGE_EDITPANEL_SUBMIT, x), x => (Errors == 0 && EditViewModel != null));
            CancelCommand = new RelayCommand(CancelExecute,  x => EditViewModel != null );
        }

        #region Command
    
        public RelayCommand UpdateCommand { get; private set; }
        public RelayCommand CreateCommand { get; private set; }
        public RelayCommand SubmitCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public abstract void UpdateExecute(Message message);
        public abstract void CreateExecute(Message message);
        public abstract void SubmitExecute(object param);
        public void CancelExecute(object param)
        {
            Controller.Messenger.DeRegister(MessageTypes.MSG_COMMAND_SELECTED_FOR_CREATE);
            Controller.Messenger.DeRegister(MessageTypes.MSG_COMMAND_SELECTED_FOR_UPDATE);
            EditViewModel.CloseViewModel(false);
            EditViewModel = null;
        }

        private bool UpdateCanExecute(object param)
        {
            return Controller.Messenger.FindAnyRegister(MessageTypes.MSG_ITEM_SELECTED_FOR_EDIT) && SelectedItem != null;
        }

        private bool CreateCanExecute(object param)
        {
            return Controller.Messenger.FindAnyRegister(MessageTypes.MSG_ITEM_SELECTED_FOR_EDIT);
        }

        #endregion

        #region Binding Properties

        public BaseViewData SelectedItem
        {
            get => GetValue(() => SelectedItem);
            set
            {
                if (SelectedItem != value)
                {
                    SetValue(() => SelectedItem, value);
                }
            }
        }

        public BaseViewModel EditViewModel
        {
            get => GetValue(() => EditViewModel);
            set
            {
                if (EditViewModel != value)
                {
                    SetValue(() => EditViewModel, value);
                }
            }
        }

        #endregion

        protected abstract void RefreshList();
        protected abstract void RefreshList(Message message);
    }
}
