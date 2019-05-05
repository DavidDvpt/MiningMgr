using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Tool")]
    public abstract class Tool : Unstackable
    {
        [Required]
        public short UsePerMin { get; set; }
    }
}
