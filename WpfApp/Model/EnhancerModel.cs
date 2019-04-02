using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Enhancer")]
    public class EnhancerModel : InWorldModel
    {
        public EnhancerModel()
        {
            
        }
        
        [Required]
        public byte Slot { get; set; }

        public decimal BonusValue1 { get; set; }

        public decimal BonusValue2 { get; set; }
    }
}
