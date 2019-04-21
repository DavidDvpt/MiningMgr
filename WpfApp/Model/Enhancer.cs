using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Enhancer")]
    public class Enhancer : InWorld
    {
        public Enhancer()
        {
            BonusValue1 = 0;
            BonusValue2 = 0;
        }

        [Range(1, 10, ErrorMessage = "Le n° du slot doit être compris entre 1 et 10")]
        public byte Slot
        {
            get { return GetValue(() => Slot); }
            set
            {
                if (value != Slot)
                {
                    SetValue(() => Slot, value);
                }
            }
        }

        [Range(0.01, 99.99, ErrorMessage = "Le bonus principal (%) est compris entre 0.01 et 99.99")]
        public decimal BonusValue1
        {
            get { return GetValue(() => BonusValue1); }
            set
            {
                if (value != BonusValue1)
                {
                    SetValue(() => BonusValue1, value);
                }
            }
        }

        [Range(0, 99, ErrorMessage = "Le bonus secondaire doit être compris entre 0 et 99")]
        public short BonusValue2
        {
            get { return GetValue(() => BonusValue2); }
            set
            {
                if (value != BonusValue2)
                {
                    SetValue(() => BonusValue2, value);
                }
            }
        }
    }
}
