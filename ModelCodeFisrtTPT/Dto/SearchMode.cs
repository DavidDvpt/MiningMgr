using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Dto
{
    [Table("SearchMode")]
    public class SearchMode : Commun
    {
        public string Abbrev { get; set; }

        public decimal Multiplicateur { get; set; }
    }
}
