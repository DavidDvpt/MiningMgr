﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Excavator")]
    public class ExcavatorDto : ToolDto
    {
        public decimal Efficienty { get; set; }
    }
}