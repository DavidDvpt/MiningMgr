using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("InWorld")]
    public abstract class InWorldDto : CommunDto
    {
        [Required]
        public decimal Value { get; set; }

        public int ModeleId { get; set; }

        [ForeignKey("ModeleId")]
        public virtual ModeleDto Modele { get; set; }
    }
}
