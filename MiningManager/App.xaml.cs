using Controllers;
using Services;
using System.Windows;
using ViewModels;

namespace MiningManager
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool mainWindow = true;

            if (mainWindow)
            {
                IMainWindowController controller = new MainWindowController(new MainWindowService());
                controller.Start();
            }
            else
            {
                //MenuController controllerMenu = new MenuController(new MenuService(), new ViewWindow());
                //controllerMenu.Start();

                //StatusController controllerStatus = new StatusController(new StatusService());
                //controllerStatus.Start();
            }
        }
    }
}


