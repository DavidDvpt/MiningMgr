using System.Windows.Controls;

namespace WpfApp.Views
{
    /// <summary>
    /// Logique d'interaction pour StockView.xaml
    /// </summary>
    public partial class StockView : UserControl
    {
        public StockView()
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
