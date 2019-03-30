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
    public partial class SetupView : UserControl
    {
        public SetupView()
        {
            InitializeComponent();
        }

        private void Creer_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show(((SetupViewModel)DataContext).ToString());
        }

        private void CbxFinderAmplifier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((SetupViewModel)DataContext).NomComposition();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            ((SetupViewModel)DataContext).Setup.DepthEnhancerQty = 5;
        }
    }
}
