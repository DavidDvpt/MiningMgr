using BaseClasses;

namespace ViewModels
{
    public class FinderMgrViewModel : BaseViewModel
    {
        public FinderMgrViewModel(IController controller) : base(controller)
        {
        }

        public FinderMgrViewModel(IController controller, IView view) : base(controller, view)
        {
            NomVisibility = true;
        }

        public bool NomVisibility
        {
            get { return GetValue(() => NomVisibility); }
            set
            {
                SetValue(() => NomVisibility, value);
            }
        }
    }
}
