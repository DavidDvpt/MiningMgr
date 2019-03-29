using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;
using System.Windows;
using WpfApp.Views;
using WpfApp.ViewModel;

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
        }

        private void SetupViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetupViewModel setupViewModelObject = new SetupViewModel();
            SetupViewControl.DataContext = setupViewModelObject;
        }

        //private void SetupViewControl_Loaded
        private void MenuItemSetupCRUD_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
