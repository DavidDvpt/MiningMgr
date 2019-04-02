using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("FinderAmplifier")]
    public class FinderAmplifierModel : UnstackableModel
    {
        public decimal Coefficient { get; set; }
    }
}
