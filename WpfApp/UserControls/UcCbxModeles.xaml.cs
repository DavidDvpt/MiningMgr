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
using WpfApp.Model.Dto.Interfaces;

namespace WpfApp.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UcCbxModeles.xaml
    /// </summary>
    public partial class UcCbxModeles : UserControl
    {
        public UcCbxModeles()
        {
            InitializeComponent();
        }

        private Modele _selected;

        public string LabelTexte
        {
            get { return (string)GetValue(LabelTexteProperty); }
            set { SetValue(LabelTexteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelTexte.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelTexteProperty =
            DependencyProperty.Register("LabelTexte", typeof(string), typeof(UcCbxModeles), new PropertyMetadata(default(string)));



        public ICollection<Modele> Modeles
        {
            get { return (ICollection<Modele>)GetValue(ModelesProperty); }
            set { SetValue(ModelesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelesProperty =
            DependencyProperty.Register("Modeles", typeof(ICollection<Modele>), typeof(UcCbxModeles), new PropertyMetadata(null));


        public Modele Selected
        {
            get { return (Modele)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Selected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(Modele), typeof(UcCbxModeles), new PropertyMetadata());


        public Style SpStyle
        {
            get { return (Style)GetValue(SpStyleProperty); }
            set { SetValue(SpStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SpStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpStyleProperty =
            DependencyProperty.Register("SpStyle", typeof(Style), typeof(UcCbxModeles), new PropertyMetadata(default(Style)));






    }
}
