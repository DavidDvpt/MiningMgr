using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("FinderAmplifier")]
    public class FinderAmplifier : UnstackableModel
    {
        public decimal Coefficient { get; set; }
    }
}
