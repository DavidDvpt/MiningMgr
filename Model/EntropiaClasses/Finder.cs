using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Finder")]
    public class Finder : Tool
    {
        [Required]
        public decimal Depth { get; set; }

        [Required]
        public decimal Range { get; set; }

        [Required]
        public short BasePecSearch { get; set; }
    }
}
