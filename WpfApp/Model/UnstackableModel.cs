using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Unstackable")]
    public abstract class UnstackableModel : InWorldModel
    {
        public UnstackableModel()
        {
            
        }
        [Required]
        public bool IsLimited { get; set; } = true;

        public decimal Decay { get; set; }

        public string Code { get; set; } = "";
    }
}
