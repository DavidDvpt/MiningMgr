using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Setup")]
    public class Setup : Commun
    {
        public int FinderId { get; set; }
        [ForeignKey("FinderId")]
        public virtual Finder Finder { get; set; }

        public int FinderAmplifierId { get; set; }
        [ForeignKey("FinderAmplifierId")]
        public virtual FinderAmplifier FinderAmplifier { get; set; }

        public int SearchModeId { get; set; }
        [ForeignKey("SearchModeId")]
        public virtual SearchMode SearchMode { get; set; }

        public short DepthEnhancerQty { get; set; } = 0;

        public short RangeEnhancerQty { get; set; } = 0;

        public short SkillEnhancerQty { get; set; } = 0;

        // Ajouter dans la migration 
        // Sql("ALTER TABLE Setup ADD CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([FinderDepthEnhancerQty] + [FinderRangeEnhancerQty] + [FinderSkillEnhancerQty]) <= 10)");

    }
}
