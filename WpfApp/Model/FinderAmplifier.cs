using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("FinderAmplifier")]
    public class FinderAmplifier : Unstackable
    {
        private decimal _coefficient;

        public decimal Coefficient
        {
            get => _coefficient;
            set
            {
                _coefficient = value;
                NotifyPropertyChanged();
            }
        }
    }
}
