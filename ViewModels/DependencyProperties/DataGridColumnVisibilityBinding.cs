using System.Windows;

namespace ViewModels.DependencyProperties
{
    public class DataGridColumnVisibilityBinding : Freezable
    {
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object),
            typeof(DataGridColumnVisibilityBinding));

        public object Data
        {
            get { return GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new DataGridColumnVisibilityBinding();
        }
    }
}
