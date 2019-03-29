using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;
using System.Windows;
using WpfApp.Fenetres;

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
            //MessageBox.Show("test");
            SetupCRUD setup = new SetupCRUD(_repo);
            setup.Show();
        }
    }
}
