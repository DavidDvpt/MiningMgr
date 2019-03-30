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
            Setup = new Setup();
            Finders = FindersLoad();
            FinderAmplifiers = FindersAmplifiersLoad();
            Setup.Finder = Finders.First();
            Setup.FinderAmplifier = FinderAmplifiers.First();
        }

        public Setup Setup { get; set; }
        
        // Affichage de la liste des finder ds le combobox
        public ICollection<Finder> Finders { get; set; }
        public ICollection<Finder> FindersLoad()
        {
            return repos.Finders.GetAll().ToList();
        }

        // Affichage de la liste des finderamplifier ds le combobox
        public ICollection<FinderAmplifier> FinderAmplifiers { get; set; }
        public ICollection<FinderAmplifier> FindersAmplifiersLoad()
        {
            return repos.FinderAmplifiers.GetAll().ToList();
        }
    }
}
