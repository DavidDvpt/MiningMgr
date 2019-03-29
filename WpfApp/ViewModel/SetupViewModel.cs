using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfApp.Model;
using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.ViewModel
{
    public class SetupViewModel : BaseViewModel
    {

        public SetupViewModel() : base()
        {
            
        }

        protected override void Init()
        {
            Setup = new Setup() { DepthEnhancerQty = 5 };
            Finders = FindersLoad();
            FinderAmplifiers = FindersAmplifiersLoad();
        }

        public Setup Setup { get; set; }

        public ICollection<Finder> Finders { get; set; }
        public ICollection<FinderAmplifier> FinderAmplifiers { get; set; }


        // Pour alimenter le combobox choix du finder
        public ICollection<Finder> FindersLoad()
        {
            return repos.Finders.GetAll().ToList();
        }

        // Pour alimenter le combobox choix du finderamplifier
        public ICollection<FinderAmplifier> FindersAmplifiersLoad()
        {
            return repos.FinderAmplifiers.GetAll().ToList();
        }
    }
}
