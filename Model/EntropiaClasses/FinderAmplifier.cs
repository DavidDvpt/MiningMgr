using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("FinderAmplifier")]
    public class FinderAmplifier : Unstackable
    {
        public decimal Coefficient { get; set; }
    }
}
