using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("ToolAccessoire")]
    public class ToolAccessoireDto
    {
        [Key]
        [Column(Order = 1)]
        public int ToolId { get; set; }

        [ForeignKey("ToolId")]
        public ModeleDto Tool { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AccessoireId { get; set; }

        [ForeignKey("AccessoireId")]
        public ModeleDto Accessoire { get; set; }
    }
}
