using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Dto
{
    [Table("Tool")]
    public abstract class Tool : Unstackable
    {
        public short UsePerMin { get; set; } = 0;
    }
}
