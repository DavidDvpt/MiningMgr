using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Categorie")]
    public class Categorie : Commun
    {
        public virtual ICollection<Modele> Modeles { get; set; }
    }
}
