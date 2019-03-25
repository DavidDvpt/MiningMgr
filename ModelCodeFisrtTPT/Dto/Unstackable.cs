using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Dto
{
    [Table("Unstackable")]
    public abstract class Unstackable : InWorld
    {
        [Required]
        public bool IsLimited { get; set; } = true;

        public decimal Decay { get; set; }
    }
}
