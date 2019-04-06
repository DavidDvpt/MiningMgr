﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Tool")]
    public abstract class ToolDto : UnstackableDto
    { 
        public short UsePerMin { get; set; } = 0;
    }
}
