using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Dto
{
    [Table("FinderAmplifier")]
    public class FinderAmplifier : Unstackable
    {
        public decimal Coefficient { get; set; }
    }
}
