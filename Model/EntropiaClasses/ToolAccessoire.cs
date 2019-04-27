using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
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
