﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelCodeFisrtTPT.Dto
{
    [Table("Enhancer")]
    public class Enhancer : InWorld
    {
        public Enhancer()
        {
            
        }
        
        [Required]
        public byte Slot { get; set; }

        public decimal BonusValue1 { get; set; }

        public decimal BonusValue2 { get; set; }
    }
}
