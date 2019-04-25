using System.Windows.Controls;

namespace WpfApp.ControlUsers
{
    /// <summary>
    /// Logique d'interaction pour FormulaireAchatUserControl.xaml
    /// </summary>
    public partial class FormulaireAchatUserControl : UserControl
    {
        public FormulaireAchatUserControl()
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
