using ModelCodeFisrtTPT.Repositories;
using ModelCodeFisrtTPT.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
