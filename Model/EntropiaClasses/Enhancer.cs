using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Enhancer")]
    public class Enhancer : InWorld
    {
        [Required]
        public byte Slot { get; set; }

        [Required]
        public decimal BonusValue1 { get; set; }

        [Required]
        public short BonusValue2 { get; set; }
    }
}
