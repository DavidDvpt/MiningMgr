using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WpfApp.Model
{
    [Table("Setup")]
    public class Setup : Commun, INotifyPropertyChanged
    {
        private int _depthEnhancerQty;
        private int _rangeEnhancerQty;
        private int _skillEnhancerQty;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int FinderId { get; set; }

        public int FinderAmplifierId { get; set; }

        public int DepthEnhancerQty
        {
            get => _depthEnhancerQty;
            set
            {
                if (value != _depthEnhancerQty)
                {
                    _depthEnhancerQty = value;
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
                    NotifyPropertyChanged();
                }
            }
        }

        [ForeignKey("FinderId")]
        public virtual Finder Finder { get; set; }
 

        [ForeignKey("FinderAmplifierId")]
        public virtual FinderAmplifier FinderAmplifier { get; set; }



        public int TierUsed()
        {
            return DepthEnhancerQty + RangeEnhancerQty + SkillEnhancerQty;
        }



        // Ajouter dans la migration 
        // Sql("ALTER TABLE Setup ADD CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([FinderDepthEnhancerQty] + [FinderRangeEnhancerQty] + [FinderSkillEnhancerQty]) <= 10)");

    }
}
