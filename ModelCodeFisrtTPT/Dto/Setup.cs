using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Dto
{
    [Table("Setup")]
    public class Setup : Commun
    {
        public int FinderId { get; set; }

        public int FinderAmplifierId { get; set; }

        public int DepthEnhancerQty { get; set; }

        public int RangeEnhancerQty { get; set; }

        public int SkillEnhancerQty { get; set; }

        [ForeignKey("FinderId")]
        public Finder Finder { get; set; }

        [ForeignKey("FinderAmplifierId")]
        public FinderAmplifier FinderAmplifier { get; set; }

        // Ajouter dans la migration 
        // Sql("ALTER TABLE Setup ADD CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([FinderDepthEnhancerQty] + [FinderRangeEnhancerQty] + [FinderSkillEnhancerQty]) <= 10)");

    }
}
