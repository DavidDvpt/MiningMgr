using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("FinderAmplifier")]
    public class FinderAmplifier : Unstackable
    {
        [Required]
        public decimal Coefficient { get; set; }
    }
}
