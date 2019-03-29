using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Setup")]
    public class Setup : Commun, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public int FinderId { get; set; }
        //{
        //    get
        //    {
        //        return FinderAmplifierId;
        //    }

        //    set
        //    {
        //        if (FinderId != value)
        //        {
        //            FinderId = value;
        //            NotifyPropertyChanged("FinderId");
        //        }
        //    }
        //}

        public int FinderAmplifierId { get; set; }
        //{
        //    get
        //    {
        //        return FinderAmplifierId;
        //    }

        //    set
        //    {
        //        if (FinderAmplifierId != value)
        //        {
        //            FinderAmplifierId = value;
        //            NotifyPropertyChanged("FinderAmplifierId");
        //        }
        //    }
        //}

        public int DepthEnhancerQty { get; set; }
        //{
        //    get
        //    {
        //        return DepthEnhancerQty;
        //    }

        //    set
        //    {
        //        if (DepthEnhancerQty != value)
        //        {
        //            DepthEnhancerQty = value;
        //            NotifyPropertyChanged("DepthEnhancerQty");
        //        }
        //    }
        //}

        public int RangeEnhancerQty { get; set; }
        //{
        //    get
        //    {
        //        return RangeEnhancerQty;
        //    }

        //    set
        //    {
        //        if (RangeEnhancerQty != value)
        //        {
        //            RangeEnhancerQty = value;
        //            NotifyPropertyChanged("RangeEnhancerQty");
        //        }
        //    }
        //}

        public int SkillEnhancerQty { get; set; }
        //{
        //    get
        //    {
        //        return SkillEnhancerQty;
        //    }

        //    set
        //    {
        //        if (SkillEnhancerQty != value)
        //        {
        //            SkillEnhancerQty = value;
        //            NotifyPropertyChanged("SkillEnhancerQty");
        //        }
        //    }
        //}

        [ForeignKey("FinderId")]
        public Finder Finder { get; set; }

        [ForeignKey("FinderAmplifierId")]
        public FinderAmplifier FinderAmplifier { get; set; }



        // Ajouter dans la migration 
        // Sql("ALTER TABLE Setup ADD CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([FinderDepthEnhancerQty] + [FinderRangeEnhancerQty] + [FinderSkillEnhancerQty]) <= 10)");

    }
}
