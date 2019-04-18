using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Setup")]
    public class Setup : Commun
    {
        public Setup()
        {
            PropertyChanged += NomComposition;
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

        [Required(ErrorMessage = "Le mode de recherche est requis dans un setup")]
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

        [Range(1, 10, ErrorMessage = "Le nombre d'enhancer doit être compris entre 1 et 10")]
        public short DepthEnhancerQty
        {
            get { return GetValue(() => DepthEnhancerQty); }
            set
            {
                if (value != DepthEnhancerQty)
                {
                    SetValue(() => DepthEnhancerQty, value);
                }
            }
        }

        [Range(1, 10, ErrorMessage = "Le nombre d'enhancer doit être compris entre 1 et 10")]
        public short RangeEnhancerQty
        {
            get { return GetValue(() => RangeEnhancerQty); }
            set
            {
                if (value != RangeEnhancerQty)
                {
                    SetValue(() => RangeEnhancerQty, value);
                }
            }
        }

        [Range(1, 10, ErrorMessage = "Le nombre d'enhancer doit être compris entre 1 et 10")]
        public short SkillEnhancerQty
        {
            get { return GetValue(() => SkillEnhancerQty); }
            set
            {
                if (value != SkillEnhancerQty)
                {
                    SetValue(() => SkillEnhancerQty, value);
                }
            }
        }

        [ForeignKey("SearchModeId")]
        [Required(ErrorMessage = "Le mode de recherche est requis dans un setup")]
        public SearchMode SearchMode
        {
            get { return GetValue(() => SearchMode); }
            set
            {
                if (value != SearchMode)
                {
                    SetValue(() => SearchMode, value);
                    SearchModeId = value.Id;
                }
            }
        }

        [ForeignKey("FinderId")]
        [Required(ErrorMessage = "Le finder est requis dans un setup")]
        public virtual Finder Finder
        {
            get { return GetValue(() => Finder); }
            set
            {
                if (value != Finder)
                {
                    SetValue(() => Finder, value);
                    FinderId = value.Id;
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
                }
            }
        }

        // cree le nom du setup à partir des outils utilises
        private void NomComposition(object sender, PropertyChangedEventArgs e)
        {
            if (Finder != null && FinderAmplifier != null && SearchMode != null)
            {
                Nom = Finder.Code + "_" + FinderAmplifier.Code + "_T" + TierUsed().ToString() + "_D" + DepthEnhancerQty.ToString() + "R" + RangeEnhancerQty.ToString() + "S" + SkillEnhancerQty.ToString() + "_" + SearchMode.Abbrev;
            }
        }

        public int TierUsed()
        {
            return DepthEnhancerQty + RangeEnhancerQty + SkillEnhancerQty;
        }
        // Ajouter dans la migration 
        // Sql("ALTER TABLE Setup ADD CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([FinderDepthEnhancerQty] + [FinderRangeEnhancerQty] + [FinderSkillEnhancerQty]) <= 10)");

    }
}
