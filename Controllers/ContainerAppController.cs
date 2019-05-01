using Services.Interfaces;
using ViewModels;
using Views;

namespace Controllers
{
    public class ContainerAppController : BaseController, IContainerAppController
    {
        private IContainerAppService _containerAppService;

        public ContainerAppController(IContainerAppService containerAppServicer)
        {
            _containerAppService = containerAppServicer;
        }

        public void Start()
        {
            ShowViewContainerApp();
        }

        private void ShowViewContainerApp()
        {
            ContainerAppView v = GetViewContainerApp();
            v.ShowInWindow(false, "Container") ;
        }

        private ContainerAppView GetViewContainerApp()
        {
            ContainerAppView v = new ContainerAppView();
            ContainerAppViewModel  vm = new ContainerAppViewModel(this, v);

            return v;
        }
    }
}
