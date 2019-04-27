using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("InWorld")]
    public abstract class InWorld : Commun
    {
        [Required]
        public decimal Value { get; set; } = 0;

        public int ModeleId { get; set; }
        [ForeignKey("ModeleId")]
        public virtual Modele Modele { get; set; }
    }
}
