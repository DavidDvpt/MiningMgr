using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Tool")]
    public abstract class Tool : Unstackable
    {
        public short UsePerMin { get; set; }
    }
}
