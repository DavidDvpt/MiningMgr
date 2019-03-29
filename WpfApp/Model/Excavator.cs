using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Excavator")]
    public class Excavator : Tool
    {
        public decimal Efficienty { get; set; }
    }
}
