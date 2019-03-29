using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("InWorld")]
    public abstract class InWorld : Commun
    {
        [Required]
        public decimal Value { get; set; }

        public int ModeleId { get; set; }

        [ForeignKey("ModeleId")]
        public virtual Modele Modele { get; set; }
    }
}
