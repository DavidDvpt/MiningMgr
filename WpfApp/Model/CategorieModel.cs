using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Categorie")]
    public class CategorieModel : CommunModel
    {
        public virtual ICollection<ModeleModel> Modeles { get; set; }
    }
}
