using System.Collections.Generic;
using System.Linq;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class SetupViewModel : BaseViewModel
    {
        // si modification du setup
        public SetupViewModel(Setup setup) : base()
        {
            Setup = setup;
            AllEnabledChange(false);
        }

        //public SetupViewModel() : base()
        //{
        //    Init();
        //}

        protected override void Init()
        {
            Setup = new Setup();
            SearchModes = SearchModesLoad();
            Finders = FindersLoad();
            FinderAmplifiers = FindersAmplifiersLoad();
            Setup.Finder = Finders.First();
            Setup.FinderAmplifier = FinderAmplifiers.First();
            Setup.SearchMode = SearchModes.First();
        }

        public Setup Setup { get; set; }

        // Affichage de la liste des searchMode ds le combobox
        public ICollection<SearchMode> SearchModes { get; set; }
        public ICollection<SearchMode> SearchModesLoad()
        {
            return repos.SearchModes.GetAll().ToList();
        }
        public bool SearchModeChoiceEnabled { get; set; } = true;


        // Affichage de la liste des finder ds le combobox
        public ICollection<Finder> Finders { get; set; }
        public ICollection<Finder> FindersLoad()
        {
            return repos.Finders.GetAll().ToList();
        }
        public bool FinderChoiceEnabled { get; set; } = true;

        // Affichage de la liste des finderamplifier ds le combobox
        public ICollection<FinderAmplifier> FinderAmplifiers { get; set; }
        public ICollection<FinderAmplifier> FindersAmplifiersLoad()
        {
            return repos.FinderAmplifiers.GetAll().ToList();
        }
        public bool FinderAmplifierChoiceEnabled { get; set; } = true;

        public bool DepthEnhancerQtyChoiceEnabled { get; set; } = true;
        public bool RangeEnhancerQtyChoiceEnabled { get; set; } = true;
        public bool SkillEnhancerQtyChoiceEnabled { get; set; } = true;

        // active ou desactive tous les controles da la vue
        private void AllEnabledChange(bool val)
        {
            SearchModeChoiceEnabled = val;
            FinderChoiceEnabled = val;
            FinderAmplifierChoiceEnabled = val;
            DepthEnhancerQtyChoiceEnabled = val;
            RangeEnhancerQtyChoiceEnabled = val;
            SkillEnhancerQtyChoiceEnabled = val;
        }

        public void CreerSetup()
        {
            repos.Setups.Add(Setup);
        }

        public void DesactiverSetup()
        {
            Setup.IsActive = false;
            repos.Setups.Update(Setup);
        }
    }
}
