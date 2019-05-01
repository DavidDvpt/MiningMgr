using System.Windows;

namespace Views
{
    /// <summary>
    /// Logique d'interaction pour ViewWindow.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {
		#region Properties

		public bool IsDialogWindow { get; set; }
		
        #endregion

		public ViewWindow()
		{
			InitializeComponent();
			IsDialogWindow = false;
		}

		public new bool? ShowDialog()
		{
			IsDialogWindow = true;
			return base.ShowDialog();
		}
    }
}
