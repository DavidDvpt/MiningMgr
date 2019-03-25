using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Dto
{
    [Table("ToolAccessoire")]
    public class ToolAccessoire
    {
        [Key]
        [Column(Order = 1)]
        public int ToolId { get; set; }

        [ForeignKey("ToolId")]
        public Modele Tool { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AccessoireId { get; set; }

        [ForeignKey("AccessoireId")]
        public Modele Accessoire { get; set; }
    }
}
