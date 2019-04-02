using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Context;
using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;

namespace WpfApp
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IRepositoriesUoW repos = new RepositoriesUoW();

            MainWindowView wnd = new MainWindowView(repos);
            wnd.Show();
        }
    }
}
