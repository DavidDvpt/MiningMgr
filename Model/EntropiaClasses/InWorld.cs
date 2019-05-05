﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("InWorld")]
    public abstract class InWorld : Commun
    {
        [Required]
        public decimal Value { get; set; }

        [Required]
        public int ModeleId { get; set; }
        [ForeignKey("ModeleId")]
        public virtual Modele Modele { get; set; }
    }
}
