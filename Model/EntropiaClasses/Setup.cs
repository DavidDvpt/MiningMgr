using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Setup")]
    public class Setup : Commun
    {
        [Required]
        public int FinderId { get; set; }
        [ForeignKey("FinderId")]
        public virtual Finder Finder { get; set; }

        public int? FinderAmplifierId { get; set; }
        [ForeignKey("FinderAmplifierId")]
        public virtual FinderAmplifier FinderAmplifier { get; set; }

        [Required]
        public int SearchModeId { get; set; }
        [ForeignKey("SearchModeId")]
        public virtual SearchMode SearchMode { get; set; }

        [Required]
        public short DepthEnhancerQty { get; set; } = 0;

        [Required]
        public short RangeEnhancerQty { get; set; } = 0;

        [Required]
        public short SkillEnhancerQty { get; set; } = 0;

        // Ajouter dans la migration 
        // Sql("ALTER TABLE Setup ADD CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([FinderDepthEnhancerQty] + [FinderRangeEnhancerQty] + [FinderSkillEnhancerQty]) <= 10)");

    }
}
