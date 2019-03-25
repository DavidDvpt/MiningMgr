using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Dto
{
    [Table("Categorie")]
    public class Categorie : Commun
    {
        public virtual ICollection<Modele> Modeles { get; set; }
    }
}
