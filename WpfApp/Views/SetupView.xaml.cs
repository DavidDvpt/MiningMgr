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

        //lance la recomposition du nom suite aux changement du finder ou de l'amplifier
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NomCompositionChanged();
        }

        //lance la recomposition du nom suite aux changement de la quantité et du type des enhancers
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            NomCompositionChanged();
        }

        // Recalcule l'affichage du Nom
        private void NomCompositionChanged()
        {
            //((SetupViewModel)DataContext).NomComposition();
        }

         private void Creer_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show(((SetupViewModel)DataContext).ToString());
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            ((SetupViewModel)DataContext).Setup.Finder = ((SetupViewModel)DataContext).Finders.First();
        }

    }
}
