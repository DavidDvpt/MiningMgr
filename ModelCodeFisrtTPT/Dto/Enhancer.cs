using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Dto
{
    [Table("Enhancer")]
    public class Enhancer : InWorld
    {
        public Enhancer()
        {
            IsStackable = true;
        }
        
        [Required]
        public byte Slot { get; set; }

        public decimal BonusValue1 { get; set; }

        public decimal BonusValue2 { get; set; }
    }
}
