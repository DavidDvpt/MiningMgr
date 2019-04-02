using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("ToolAccessoire")]
    public class ToolAccessoireModel
    {
        [Key]
        [Column(Order = 1)]
        public int ToolId { get; set; }

        [ForeignKey("ToolId")]
        public ModeleModel Tool { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AccessoireId { get; set; }

        [ForeignKey("AccessoireId")]
        public ModeleModel Accessoire { get; set; }
    }
}
