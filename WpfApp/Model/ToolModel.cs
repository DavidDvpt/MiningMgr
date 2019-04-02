using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Tool")]
    public abstract class ToolModel : UnstackableModel
    {
        public ToolModel()
        {
        }
        
        public short UsePerMin { get; set; } = 0;
    }
}
