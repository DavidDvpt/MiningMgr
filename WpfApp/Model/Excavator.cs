using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Excavator")]
    public class Excavator : Tool
    {
        private decimal _efficienty = 0;

        public decimal Efficienty
        {
            get => _efficienty;
            set
            {
                _efficienty = value;
                NotifyPropertyChanged();
            }
        }
    }
}
