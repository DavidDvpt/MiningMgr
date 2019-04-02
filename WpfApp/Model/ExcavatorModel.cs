using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Excavator")]
    public class ExcavatorModel : ToolModel
    {
        public decimal Efficienty { get; set; }
    }
}
