using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Tool")]
    public abstract class ToolDto : UnstackableDto
    {
        public ToolDto()
        {
        }
        
        public short UsePerMin { get; set; } = 0;
    }
}
