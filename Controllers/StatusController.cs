using BaseClasses;
using Services.Interfaces;
using System.Windows.Controls;
using ViewModels;
using Views;

namespace Controllers
{
    public class StatusController : BaseController
    {
        private IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        public void Start()
        {
            ShowViewStatus();
        }

        private void ShowViewStatus()
        {
            StatusView v = GetViewStatus();
            v.ShowInWindow(false, "Test", 600, 400, Dock.Bottom, null);
        }

        private StatusView GetViewStatus()
        {
            StatusView v = new StatusView();
            StatusViewModel vm = new StatusViewModel(this, v);

            return v;
        }
    }
}
