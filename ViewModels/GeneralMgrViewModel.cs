using BaseClasses;

namespace ViewModels
{
    public abstract class GeneralMgrViewModel : BaseViewModel
    {
        public GeneralMgrViewModel(IController controller) : this(controller, null)
        {
        }

        public GeneralMgrViewModel(IController controller, IView view) : base(controller, view)
        {
            UpdateCommand = new RelayCommand(x => { Controller.Messenger.NotifyColleagues(MessageTypes.MSG_COMMAND_AFFICHAGE_FINDERMGR); }, UpdateCanExecute); //x => { Controller.Messenger.NotifyColleagues(MessageTypes.MSG_COMMAND_AFFICHAGE_FINDERMGR); }
            CreateCommand = new RelayCommand(CreateExecute, CreateCanExecute);
            SubmitCommand = new RelayCommand(SubmitExecute, SubmitCanExecute);
            CancelCommand = new RelayCommand(CancelExecute, CancelCanExecute);
        }

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

        #region Command
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand SubmitCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public bool CancelCanExecute(object param)
        {
            return true;
        }

        public bool UpdateCanExecute(object param)
        {
            return SelectedItem != null;
        }
        public bool CreateCanExecute(object param)
        {
            return true;
        }
        public bool SubmitCanExecute(object param)
        {
            return true;
        }

        public void UpdateExecute(object param)
        {
            
        }
        public virtual void CreateExecute(object param)
        {

        }
        public virtual void SubmitExecute(object param)
        {

        }
        public void CancelExecute(object param)
        {

        }

        #endregion

        #region Binding Properties

        public int MyProperty { get; set; }


        #endregion
    }
}
