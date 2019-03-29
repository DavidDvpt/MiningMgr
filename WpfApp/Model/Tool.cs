using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Tool")]
    public abstract class Tool : Unstackable
    {
        public Tool()
        {
        }
        
        public short UsePerMin { get; set; } = 0;
    }
}
