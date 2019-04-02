using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Modele")]
    public class ModeleModel : CommunModel
    {
        [Required]
        public bool IsStackable { get; set; } = false;

        public int CategorieId { get; set; }

        [ForeignKey("CategorieId")]
        public virtual CategorieModel Categorie {get; set;}

        public virtual ICollection<InWorldModel> InWorlds { get; set; }
    }
}
