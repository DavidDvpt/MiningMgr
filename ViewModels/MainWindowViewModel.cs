namespace ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel(IController controller)
            : base(controller)
        {
        }

        public MainWindowViewModel(IController controller, IView view)
            : base(controller, view)
        {
        }
    }
}
