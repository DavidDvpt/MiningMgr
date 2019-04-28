using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Enhancer")]
    public class Enhancer : InWorld
    {
        public Enhancer()
        {
            BonusValue1 = 0;
            BonusValue2 = 0;
        }

        public byte Slot { get; set; }

        public decimal BonusValue1 { get; set; }

        public short BonusValue2 { get; set; }
    }
}
