using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Setup")]
    public class Setup : Commun
    {
        private int _finderId;
        private Finder _finder;
        private int _finderAmplifierId;
        private FinderAmplifier _finderAmplifier;
        private int _searchModeId;
        private SearchMode _searchMode;
        private short _depthEnhancerQty;
        private short _rangeEnhancerQty;
        private short _skillEnhancerQty;

        public Setup()
        {
            SearchMode = new SearchMode();
            Finder = new Finder();
            FinderAmplifier = new FinderAmplifier();
            PropertyChanged += NomComposition;
        }


        public int FinderId
        {
            get => _finderId;
            set
            {
                _finderId = value;
                NotifyPropertyChanged();
            }
        }

        public int FinderAmplifierId
        {
            get => _finderAmplifierId;
            set
            {
                _finderAmplifierId = value;
                NotifyPropertyChanged();
            }
        }

        public int SearchModeId
        {
            get => _searchModeId;
            set
            {
                _searchModeId = value;
                NotifyPropertyChanged();
            }
        }

        public short DepthEnhancerQty
        {
            get => _depthEnhancerQty;
            set
            {
                _depthEnhancerQty = value;
                NotifyPropertyChanged();
            }
        }

        public short RangeEnhancerQty
        {
            get => _rangeEnhancerQty;
            set
            {
                _rangeEnhancerQty = value;
                NotifyPropertyChanged();
            }
        }

        public short SkillEnhancerQty
        {
            get => _skillEnhancerQty;
            set
            {
                _skillEnhancerQty = value;
                NotifyPropertyChanged();
            }
        }

        [ForeignKey("SearchModeId")]
        public SearchMode SearchMode
        {
            get => _searchMode;
            set
            {
                _searchMode = value;
                NotifyPropertyChanged();
            }
        }

        [ForeignKey("FinderId")]
        public virtual Finder Finder
        {
            get => _finder;
            set
            {
                _finder = value;
                NotifyPropertyChanged();
            }
        }

        [ForeignKey("FinderAmplifierId")]
        public virtual FinderAmplifier FinderAmplifier
        {
            get => _finderAmplifier;
            set
            {
                _finderAmplifier = value;
                NotifyPropertyChanged();
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
