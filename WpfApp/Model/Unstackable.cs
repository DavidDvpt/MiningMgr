using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Unstackable")]
    public abstract class Unstackable : InWorld
    {
        public Unstackable()
        {
            
        }
        [Required]
        public bool IsLimited { get; set; } = true;

        public decimal Decay { get; set; }
    }
}
