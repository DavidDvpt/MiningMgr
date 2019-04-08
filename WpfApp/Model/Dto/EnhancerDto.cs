using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Enhancer")]
    public class EnhancerDto : InWorldDto
    {
        #region SiPoco
        //[Required]
        //public byte Slot { get; set; }

        //public decimal BonusValue1 { get; set; }

        //public decimal BonusValue2 { get; set; }
        #endregion

        #region SiDto
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
        #endregion
    }
}
