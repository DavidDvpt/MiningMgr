using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WpfApp.AttributValidation;

namespace WpfApp.Model
{
    [Table("Setup")]
    public class Setup : Commun
    {
        public Setup()
        {
            DepthEnhancerQty = 0;
            RangeEnhancerQty = 0;
            SkillEnhancerQty = 0;
        }

        public int FinderId
        {
            get { return GetValue(() => FinderId); }
            set
            {
                if (value != FinderId)
                {
                    SetValue(() => FinderId, value);
                }
            }
        }

        public int FinderAmplifierId
        {
            get { return GetValue(() => FinderAmplifierId); }
            set
            {
                if (value != FinderAmplifierId)
                {
                    SetValue(() => FinderAmplifierId, value);
                }
            }
        }

        public int SearchModeId
        {
            get { return GetValue(() => SearchModeId); }
            set
            {
                if (value != SearchModeId)
                {
                    SetValue(() => SearchModeId, value);
                }
            }
        }

        [Range(0, 10, ErrorMessage = "Le nombre d'enhancer doit être compris entre 1 et 10")]
        [MaxEnhancer(ErrorMessage = "Un outil peut accepter que 10 Enhancers maximum")]
        public short DepthEnhancerQty
        {
            get { return GetValue(() => DepthEnhancerQty); }
            set
            {
                if (value != DepthEnhancerQty)
                {
                    SetValue(() => DepthEnhancerQty, value);
                    NomComposition();
                }
            }
        }

        [Range(0, 10, ErrorMessage = "Le nombre d'enhancer doit être compris entre 1 et 10")]
        [MaxEnhancer(ErrorMessage = "Un outil peut accepter que 10 Enhancers maximum")]
        public short RangeEnhancerQty
        {
            get { return GetValue(() => RangeEnhancerQty); }
            set
            {
                if (value != RangeEnhancerQty)
                {
                    SetValue(() => RangeEnhancerQty, value);
                    NomComposition();
                }
            }
        }

        [Range(0, 10, ErrorMessage = "Le nombre d'enhancer doit être compris entre 1 et 10")]
        [MaxEnhancer(ErrorMessage = "Un outil peut accepter que 10 Enhancers maximum")]
        public short SkillEnhancerQty
        {
            get { return GetValue(() => SkillEnhancerQty); }
            set
            {
                if (value != SkillEnhancerQty)
                {
                    SetValue(() => SkillEnhancerQty, value);
                    NomComposition();
                }
            }
        }

        [ForeignKey("SearchModeId")]
        [Required(ErrorMessage = "Le mode de recherche est requis.")]
        public virtual SearchMode SearchMode
        {
            get { return GetValue(() => SearchMode); }
            set
            {
                if (value != SearchMode)
                {
                    SetValue(() => SearchMode, value);
                    SearchModeId = value.Id;
                    NomComposition();
                }
            }
        }

        [ForeignKey("FinderId")]
        [Required(ErrorMessage = "Le finder est requis.")]
        public virtual Finder Finder
        {
            get { return GetValue(() => Finder); }
            set
            {
                if (value != Finder)
                {
                    SetValue(() => Finder, value);
                    FinderId = value.Id;
                    NomComposition();
                }
            }
        }

        [ForeignKey("FinderAmplifierId")]
        public virtual FinderAmplifier FinderAmplifier
        {
            get { return GetValue(() => FinderAmplifier); }
            set
            {
                if (value != FinderAmplifier)
                {
                    SetValue(() => FinderAmplifier, value);
                    FinderAmplifierId = value.Id;
                    NomComposition();
                }
            }
        }

        // cree le nom du setup à partir des outils utilises
        private void NomComposition()
        {
            string searchModeAbbrev = "";
            string finderCode = "";
            string finderAmplifierCode = "";

            if (Finder != null)
            {
                finderCode = Finder.Code;
            }

            if (FinderAmplifier != null)
            {
                finderAmplifierCode = FinderAmplifier.Code;
            }

            if (SearchMode != null)
            {
                searchModeAbbrev = SearchMode.Abbrev;
            }

            Nom = finderCode + "_" + finderAmplifierCode + "_T" + TierUsed().ToString() + "_D" + DepthEnhancerQty.ToString() + "R" + RangeEnhancerQty.ToString() + "S" + SkillEnhancerQty.ToString() + "_" + searchModeAbbrev;
        }

        public int TierUsed()
        {
            return DepthEnhancerQty + RangeEnhancerQty + SkillEnhancerQty;
        }
        // Ajouter dans la migration 
        // Sql("ALTER TABLE Setup ADD CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([FinderDepthEnhancerQty] + [FinderRangeEnhancerQty] + [FinderSkillEnhancerQty]) <= 10)");

    }
}
