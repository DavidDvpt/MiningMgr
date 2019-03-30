using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Setup")]
    public class Setup : Commun, INotifyPropertyChanged
    {
        private SearchMode _searchMode;
        private int _depthEnhancerQty;
        private int _rangeEnhancerQty;
        private int _skillEnhancerQty;
        private Finder _finder;
        private FinderAmplifier _finderAmplifier;

        public int FinderId { get; set; }

        public int FinderAmplifierId { get; set; }

        public int SearchModeId { get; set; }

        public int DepthEnhancerQty
        {
            get => _depthEnhancerQty;
            set
            {
                if (value != _depthEnhancerQty)
                {
                    _depthEnhancerQty = value;
                    NomComposition();
                    NotifyPropertyChanged();
                }
            }
        }

        public int RangeEnhancerQty
        {
            get => _rangeEnhancerQty;
            set
            {
                if (value != _rangeEnhancerQty)
                {
                    _rangeEnhancerQty = value;
                    NomComposition();
                    NotifyPropertyChanged();
                }
            }
        }

        public int SkillEnhancerQty
        {
            get => _skillEnhancerQty;
            set
            {
                if (value != _skillEnhancerQty)
                {
                    _skillEnhancerQty = value;
                    NomComposition();
                    NotifyPropertyChanged();
                }
            }
        }

        [ForeignKey("SearchModeId")]
        public SearchMode SearchMode
        {
            get => _searchMode;
            set
            {
                if (value != _searchMode)
                {
                    _searchMode = value;
                    //SearchModeId = SearchMode.Id
                    NomComposition();
                    NotifyPropertyChanged();
                }
            }
        }

        [ForeignKey("FinderId")]
        public virtual Finder Finder
        {
            get => _finder;
            set
            {
                if (value != _finder)
                {
                    _finder = value;
                    //FinderId = Finder.Id;
                    NomComposition();
                    NotifyPropertyChanged();
                }
            }
        }

        [ForeignKey("FinderAmplifierId")]
        public virtual FinderAmplifier FinderAmplifier
        {
            get => _finderAmplifier;
            set
            {
                if (value != _finderAmplifier)
                {
                    _finderAmplifier = value;
                    //FinderAmplifierId = FinderAmplifier.Id;
                    NomComposition();
                    NotifyPropertyChanged();
                }
            }
        }

        // cree le nom du setup à partir des outils utilises
        private void NomComposition()
        {
            if (Finder != null && FinderAmplifier != null && SearchMode != null)
            {
                Nom = Finder.Code + "_" + FinderAmplifier.Code + "_T" + TierUsed().ToString() + "_D" + DepthEnhancerQty.ToString() + "R" + RangeEnhancerQty.ToString() + "S" + SkillEnhancerQty.ToString() + "_" + SearchMode.Abbrev;
            }
        }

        // retourne le nombre d'enhancers poses sur le tool
        public int TierUsed()
        {
            return DepthEnhancerQty + RangeEnhancerQty + SkillEnhancerQty;
        }



        // Ajouter dans la migration 
        // Sql("ALTER TABLE Setup ADD CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([FinderDepthEnhancerQty] + [FinderRangeEnhancerQty] + [FinderSkillEnhancerQty]) <= 10)");

    }
}
