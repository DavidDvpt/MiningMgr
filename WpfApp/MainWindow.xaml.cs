using WpfApp.Repositories.Interfaces;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        private IRepositoriesUoW _repo;

        public MainWindowView(IRepositoriesUoW repo)
        {
            InitializeComponent();
            //if (repo != null)
            //{
                _repo = repo;
            //}
            //else
            //{
            //    throw new NullReferenceException("Les repositories ne sont pas initialisés");
            //}
        }

        public MainWindowView()
        {
            InitializeComponent();
        }
    }
}
