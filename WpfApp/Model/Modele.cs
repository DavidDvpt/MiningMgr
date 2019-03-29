using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Modele")]
    public class Modele : Commun
    {
        [Required]
        public bool IsStackable { get; set; } = false;

        public int CategorieId { get; set; }

        [ForeignKey("CategorieId")]
        public virtual Categorie Categorie {get; set;}

        public virtual ICollection<InWorld> InWorlds { get; set; }
    }
}
