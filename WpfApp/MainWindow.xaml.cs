using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;
using System.Windows;
using WpfApp.Views;

namespace WpfApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRepositoriesUoW _repo;
        public MainWindow()
        {
            InitializeComponent();
            _repo = new RepositoriesUoW();
            DataContext = _repo;
            
        }

        private void MenuItemSetupCRUD_Click(object sender, RoutedEventArgs e)
        {
            SetupView sv = new SetupView();
            container.
            ////MessageBox.Show("test");
            //SetupView setup = new SetupView();
            //setup.Show();
        }
    }
}
