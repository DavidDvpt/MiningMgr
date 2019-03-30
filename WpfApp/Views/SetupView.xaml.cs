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
using WpfApp.Model;
using WpfApp.ViewModel;

namespace WpfApp.Views
{
    /// <summary>
    /// Logique d'interaction pour SetupView.xaml
    /// </summary>
    /// 
    public partial class SetupView : UserControl
    {
        public SetupView()
        {
            InitializeComponent();

            //this.DataContext = new SetupViewModel();
            //this.DataContext = new SetupViewModel(new Setup());
        }

        public SetupView(Setup setup)
        {
            InitializeComponent();

            if (setup == null)
            {
                setup = new Setup();
            }

            this.DataContext = new SetupViewModel();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Desactiver_Click(object sender, RoutedEventArgs e)
        {
            //((SetupViewModel)DataContext).DesactiverSetup();
        }
    }
}
