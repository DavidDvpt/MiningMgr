using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WpfApp.Model
{
    [Table("Categorie")]
    public class Categorie : Commun
    {
        public Categorie()
        {
            Modeles = new List<Modele>();
        }
        public virtual ICollection<Modele> Modeles { get; set; }
    }
}
