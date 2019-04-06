using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Setup")]
    public class SetupDto : CommunDto
    {
        public int FinderId { get; set; }

        public int FinderAmplifierId { get; set; }

        public int SearchModeId { get; set; }

        public short DeptEnhancerQty { get; set; }

        public short RangeEnhancerQty { get; set; }

        public short SkillEnhancerQty { get; set; }

        [ForeignKey("SearchModeId")]
        public SearchModeDto SearchMode { get; set; }

        [ForeignKey("FinderId")]
        public virtual FinderDto Finder { get; set; }

        [ForeignKey("FinderAmplifierId")]
        public virtual FinderAmplifierDto FinderAmplifier { get; set; }

        // Ajouter dans la migration 
        // Sql("ALTER TABLE Setup ADD CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([FinderDepthEnhancerQty] + [FinderRangeEnhancerQty] + [FinderSkillEnhancerQty]) <= 10)");

    }
}
