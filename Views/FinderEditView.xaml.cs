using BaseClasses;
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

namespace Views
{
    /// <summary>
    /// Logique d'interaction pour FinderEditView.xaml
    /// </summary>
    public partial class FinderEditView : BaseView
    {
        public FinderEditView()
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
