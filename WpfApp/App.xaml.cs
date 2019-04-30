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
            MenuController controller = new MenuController(new MenuService());
            controller.Start();
        }
    }
}
