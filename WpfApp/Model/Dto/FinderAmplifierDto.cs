using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("FinderAmplifier")]
    public class FinderAmplifierDto : UnstackableDto
    {
        public decimal Coefficient { get; set; }
    }
}
