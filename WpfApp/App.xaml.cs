using Controllers;
using Services;
using Services.Interfaces;
using System.Windows;

namespace MiningManager
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MenuController controllerMenu = new MenuController(new MenuService());
            controllerMenu.Start();

            StatusController controllerStatus = new StatusController(new IStatusService());
            controllerStatus.Start();
        }
    }
}
