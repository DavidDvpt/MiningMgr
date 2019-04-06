using System.ComponentModel;
using WpfApp.Model.Dto;

namespace WpfApp.Model.Poco
{
    public class SetupPoco : CommunPoco<SetupDto>
    {
        public SetupPoco()
        {
            PropertyChanged += NomComposition;
        }
        public int FinderId
        {
            get => _Dto.FinderId;
            set
            {
                _Dto.FinderId = value;
                NotifyPropertyChanged();
            }
        }

        public int FinderAmplifierId
        {
            get => _Dto.FinderAmplifierId;
            set
            {
                _Dto.FinderAmplifierId = value;
                NotifyPropertyChanged();
            }
        }

        public int SearchModeId
        {
            get => _Dto.SearchModeId;
            set
            {
                _Dto.SearchModeId = value;
                NotifyPropertyChanged();
            }
        }

        public short DepthEnhancerQty
        {
            get => _Dto.DeptEnhancerQty;
            set
            {
                if (value != _Dto.DeptEnhancerQty && TierUsed() <= 10)
                {
                    _Dto.DeptEnhancerQty = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public short RangeEnhancerQty
        {
            get => _Dto.RangeEnhancerQty;
            set
            {
                if (value != _Dto.RangeEnhancerQty && TierUsed() <= 10)
                {
                    _Dto.RangeEnhancerQty = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public short SkillEnhancerQty
        {
            get => _Dto.SkillEnhancerQty;
            set
            {
                if (value != _Dto.SkillEnhancerQty && TierUsed() <= 10)
                {
                    _Dto.SkillEnhancerQty = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public SearchModeDto SearchMode
        {
            get => _Dto.SearchMode;
            set
            {
                if (value != _Dto.SearchMode)
                {
                    _Dto.SearchMode = value;
                    //SearchModeId = SearchMode.Id
                    NotifyPropertyChanged();
                }
            }
        }
        
        public virtual FinderDto Finder
        {
            get => _Dto.Finder;
            set
            {
                if (value != _Dto.Finder)
                {
                    _Dto.Finder = value;
                    //FinderId = Finder.Id;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public virtual FinderAmplifierDto FinderAmplifier
        {
            get => _Dto.FinderAmplifier;
            set
            {
                if (value != _Dto.FinderAmplifier)
                {
                    _Dto.FinderAmplifier = value;
                    //FinderAmplifierId = FinderAmplifier.Id;
                    NotifyPropertyChanged();
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

        // retourne le nombre d'enhancers poses sur le tool
        public int TierUsed()
        {
            return DepthEnhancerQty + RangeEnhancerQty + SkillEnhancerQty;
        }
    }
}
