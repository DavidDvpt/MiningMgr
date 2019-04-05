using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Categorie")]
    public class CategorieDto : CommunDto
    {
        public virtual ICollection<ModeleDto> Modeles { get; set; }
    }
}
