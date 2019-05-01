namespace ViewModels
{
    public class ContainerAppViewModel : BaseViewModel
    {
        public ContainerAppViewModel(IController controller) : base(controller)
        {
        }

        public ContainerAppViewModel(IController controller, IView view) : base(controller, view)
        {
        }
    }
}
