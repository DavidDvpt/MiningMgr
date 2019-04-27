using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Finder")]
    public class Finder : Tool
    {
        [Required]
        public decimal Depth { get; set; } = 0;

        [Required]
        public decimal Range { get; set; } = 0;

        [Required]
        public short BasePecSearch { get; set; } = 0;
    }
}
