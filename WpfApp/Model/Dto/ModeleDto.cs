using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Modele")]
    public class ModeleDto : CommunDto
    {
        [Required]
        public bool IsStackable { get; set; } = false;

        public int CategorieId { get; set; }

        [ForeignKey("CategorieId")]
        public virtual CategorieDto Categorie {get; set;}

        public virtual ICollection<InWorldDto> InWorldsDto { get; set; }
    }
}
