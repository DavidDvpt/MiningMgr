using System.Collections.Generic;
using System.Linq;
using WpfApp.Model.Poco;

namespace WpfApp.ViewModel
{
    public class SetupManagerViewModel : ManagerViewModel<SetupPoco>
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
            DataGridItemSource = repos.SetupsPoco.GetAll().ToList();
        }

        public MyICommand CreerCommand { get; set; }
        public SetupPoco SetupPoco { get; set; }

        // Affichage de la liste des searchMode ds le combobox
        public ICollection<SearchModePoco> SearchModes { get; set; }
        public ICollection<SearchModePoco> SearchModesLoad()
        {
            return repos.SearchModesPoco.GetAll().ToList();
        }
        public bool SearchModeChoiceEnabled { get; set; } = true;


        // Affichage de la liste des finder ds le combobox
        public ICollection<FinderPoco> Finders { get; set; }
        public ICollection<FinderPoco> FindersLoad()
        {
            return repos.FindersPoco.GetAll().ToList();
        }
        public bool FinderChoiceEnabled { get; set; } = true;

        // Affichage de la liste des finderamplifier ds le combobox
        public ICollection<FinderAmplifierPoco> FinderAmplifiers { get; set; }
        public ICollection<FinderAmplifierPoco> FindersAmplifiersLoad()
        {
            return repos.FinderAmplifiersPoco.GetAll().ToList();
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
            repos.SetupsPoco.Add(SetupPoco);
        }
        public bool CanCreate()
        {
            return true;
        }

        public void DesactiverSetup()
        {
            SetupPoco.IsActive = false;
            repos.SetupsPoco.Update(SetupPoco);
        }

    }
}
