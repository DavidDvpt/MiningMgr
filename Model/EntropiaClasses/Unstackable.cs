using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Unstackable")]
    public abstract class Unstackable : InWorld
    {
        [Required]
        public bool IsLimited { get; set; } = true;

        [Required]
        public decimal Decay { get; set; } = 0;

        public string Code { get; set; } = "";
    }
}
