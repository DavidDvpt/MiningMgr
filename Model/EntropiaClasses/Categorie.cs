using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Categorie")]
    public class Categorie : Commun
    {
        public virtual ICollection<Modele> Modeles { get; set; }

    }
}
