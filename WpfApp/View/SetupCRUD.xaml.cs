using WpfApp.Model;
using WpfApp.Repositories.Interfaces;
using System.Linq;
using System.Windows;

namespace WpfApp.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour SetupCRUD.xaml
    /// </summary>
    public partial class SetupCRUD : Window
    {
        private IRepositoriesUoW _repo;

        public SetupCRUD(IRepositoriesUoW ctx)
        {
            InitializeComponent();
            _repo = ctx;

            //cbxFinder.ItemsSource =_repo.Finders.GetAll().ToList();
        }

        public SetupCRUD(Setup setup)
        {
            InitializeComponent();
            this.DataContext = setup;
            //cbxFinder.ItemsSource = new List<string> { "dudul", "plor" };//_repo.Finders.GetAll();
            //cbxFinder.ItemsSource = _repo.FinderAmplifiers.GetAll();
            dhQty.Text = _repo.FinderAmplifiers.GetAll().Count().ToString();
            //MessageBox.Show(_repo.FinderAmplifiers.GetAll().ToString());
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            dhQty.Text = _repo.FinderAmplifiers.GetAll().Count().ToString();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
