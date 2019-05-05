using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Unstackable")]
    public abstract class Unstackable : InWorld
    {
        [Required]
        public bool IsLimited { get; set; }

        [Required]
        public decimal Decay { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }
    }
}
