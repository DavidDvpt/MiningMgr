using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("InWorld")]
    public abstract class InWorldModel : CommunModel
    {
        [Required]
        public decimal Value { get; set; }

        public int ModeleId { get; set; }

        [ForeignKey("ModeleId")]
        public virtual ModeleModel Modele { get; set; }
    }
}
