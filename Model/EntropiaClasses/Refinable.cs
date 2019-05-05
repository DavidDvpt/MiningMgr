using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Refinable")]
    public class Refinable
    {
        [Key]
        [Column(Order = 1)]
        public int UnrefinedId { get; set; }
        [ForeignKey("UnrefinedId")]
        public virtual Material UnrefinedMaterial { get; set; }

        [Key]
        [Column(Order = 2)]
        public int RefinedId { get; set; }
        [ForeignKey("RefinedId")]
        public virtual Material RefinedMaterial { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
