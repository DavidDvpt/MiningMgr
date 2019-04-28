using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Excavator")]
    public class Excavator : Tool
    {
        public decimal Efficienty { get; set; }
    }
}
