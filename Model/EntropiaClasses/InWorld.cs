using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("InWorld")]
    public abstract class InWorld : Commun
    {
        public decimal Value { get; set; }

        public int ModeleId { get; set; }
        [ForeignKey("ModeleId")]
        public virtual Modele Modele { get; set; }
    }
}
