﻿using ModelCodeFisrtTPT.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Dto
{
    [Table("Commun")]
    public abstract class Commun
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50,ErrorMessage = "La longueur maximum est de 50")]
        [Index(IsUnique = true)]
        public string Nom { get; set; }

        [Required]

        public bool IsActive { get; set; } = true;
    }
}
