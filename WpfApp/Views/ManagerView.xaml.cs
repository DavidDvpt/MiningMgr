using System.Windows.Controls;
using WpfApp.ViewModel;

namespace WpfApp.Views
{
    /// <summary>
    /// Logique d'interaction pour ManagerView.xaml
    /// </summary>
    public partial class ManagerView : UserControl
    {
        public ManagerView()
        {
            InitializeComponent();
        }


        protected void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) BindableBase.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) BindableBase.Errors -= 1;
        }
    }
}
