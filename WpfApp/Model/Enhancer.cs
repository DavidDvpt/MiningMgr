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

        [Range(1,10, ErrorMessage = "Le n° du slot doit être compris entre 1 et 10")]
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

        public decimal BonusValue2
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
