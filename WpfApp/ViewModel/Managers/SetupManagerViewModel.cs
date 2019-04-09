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
            DataGridItemSource = repos.SetupsDto.GetAll().ToList();
        }

        public MyICommand CreerCommand { get; set; }
        public SetupDto SetupDto { get; set; }

        // Affichage de la liste des searchMode ds le combobox
        public ICollection<SearchModeDto> SearchModes { get; set; }
        public ICollection<SearchModeDto> SearchModesLoad()
        {
            return repos.SearchModesDto.GetAll().ToList();
        }
        public bool SearchModeChoiceEnabled { get; set; } = true;


        // Affichage de la liste des finder ds le combobox
        public ICollection<FinderDto> Finders { get; set; }
        public ICollection<FinderDto> FindersLoad()
        {
            return repos.FindersDto.GetAll().ToList();
        }
        public bool FinderChoiceEnabled { get; set; } = true;

        // Affichage de la liste des finderamplifier ds le combobox
        public ICollection<FinderAmplifierDto> FinderAmplifiers { get; set; }
        public ICollection<FinderAmplifierDto> FindersAmplifiersLoad()
        {
            return repos.FinderAmplifiersDto.GetAll().ToList();
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
            repos.SetupsDto.Add(SetupDto);
        }
        public bool CanCreate()
        {
            return true;
        }

        public void DesactiverSetup()
        {
            SetupDto.IsActive = false;
            repos.SetupsDto.Update(SetupDto);
        }

        protected override void ValiderItem()
        {
            throw new System.NotImplementedException();
        }
    }
}
