using Services.Interfaces;
using ViewModels;
using Views;

namespace Controllers
{
    public class MainWindowController : BaseController, IMainWindowController
    {
        private IMainWindowService mainWindowService;

        public MainWindowController(IMainWindowService mws)
        {
            mainWindowService = mws;
        }

        public void Start()
        {
            ShowViewMainWindow();
        }

        private void ShowViewMainWindow()
        {
            MainWindow v = GetViewMainWindow();
        }

        private MainWindow GetViewMainWindow()
        {
            MainWindow v = new MainWindow();
            MainWindowViewModel mv = new MainWindowViewModel(this, v);
        }
    }
}
