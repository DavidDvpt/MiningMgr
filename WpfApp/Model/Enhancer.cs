using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Enhancer")]
    public class Enhancer : InWorld
    {
        private byte _slot;
        private decimal _bonusValue1;
        private decimal _bonusValue2;

        public byte Slot
        {
            get => _slot;
            set
            {
                _slot = value;
                NotifyPropertyChanged();
            }
        }

        public decimal BonusValue1
        {
            get => _bonusValue1;
            set
            {
                _bonusValue1 = value;
                NotifyPropertyChanged();
            }
        }

        public decimal BonusValue2
        {
            get => _bonusValue2;
            set
            {
                _bonusValue2 = value;
                NotifyPropertyChanged();
            }
        }
    }
}
