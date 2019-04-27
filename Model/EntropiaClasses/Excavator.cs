using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Excavator")]
    public class Excavator : Tool
    {
        [Required]
        public decimal Efficienty { get; set; } = 0;
    }
}
