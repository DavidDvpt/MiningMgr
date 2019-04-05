using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Categorie")]
    public class CategorieDto : CommunDto
    {
        public virtual ICollection<ModeleDto> ModelesDto { get; set; }
    }
}
