using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Enhancer")]
    public class Enhancer : InWorld
    {
        public Enhancer()
        {
            BonusValue1 = 0;
            BonusValue2 = 0;
        }

        [Required]
        public byte Slot { get; set; } = 1;

        [Required]
        public decimal BonusValue1 { get; set; } = 0;

        public short BonusValue2 { get; set; } = 0;
    }
}
