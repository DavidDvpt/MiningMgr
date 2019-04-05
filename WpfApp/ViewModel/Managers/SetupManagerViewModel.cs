using System.Collections.Generic;
using System.Linq;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    public class SetupManagerViewModel : ManagerViewModel<SetupDto>
    {
        protected override void ColumnInit()
        {
            NomVisibility = true;
            SearchModeVisibility = true;
            FinderVisibility = true;
            FinderAmplifierVisibility = true;
            DepthEnhancerQtyVisibility = true;
            RangeEnhancerQtyVisibility = true;
            SkillEnhancerQtyVisibility = true;
        }

        protected override void Init()
        {
            //if (Setup == null)
            //    Setup = new SetupModel();
            //SearchModes = SearchModesLoad();
            //Finders = FindersLoad();
            //FinderAmplifiers = FindersAmplifiersLoad();
            //Setup.Finder = Finders.First();
            //Setup.FinderAmplifier = FinderAmplifiers.First();
            //Setup.SearchMode = SearchModes.First();
            //CreerCommand = new MyICommand(OnCreate, CanCreate);
            DataGridItemSource = repos.Setups.GetAll().ToList();
        }

        public MyICommand CreerCommand { get; set; }
        public SetupDto Setup { get; set; }

        // Affichage de la liste des searchMode ds le combobox
        public ICollection<SearchModeDto> SearchModes { get; set; }
        public ICollection<SearchModeDto> SearchModesLoad()
        {
            return repos.SearchModes.GetAll().ToList();
        }
        public bool SearchModeChoiceEnabled { get; set; } = true;


        // Affichage de la liste des finder ds le combobox
        public ICollection<FinderDto> Finders { get; set; }
        public ICollection<FinderDto> FindersLoad()
        {
            return repos.Finders.GetAll().ToList();
        }
        public bool FinderChoiceEnabled { get; set; } = true;

        // Affichage de la liste des finderamplifier ds le combobox
        public ICollection<FinderAmplifierDto> FinderAmplifiers { get; set; }
        public ICollection<FinderAmplifierDto> FindersAmplifiersLoad()
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

        public void OnCreate()
        {
            repos.Setups.Add(Setup);
        }
        public bool CanCreate()
        {
            return true;
        }

        public void DesactiverSetup()
        {
            Setup.IsActive = false;
            repos.Setups.Update(Setup);
        }

    }
}
