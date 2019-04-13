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
            IsActiveVisibility = true;
            SearchModeVisibility = true;
            FinderVisibility = true;
            FinderAmplifierVisibility = true;
            DepthEnhancerQtyVisibility = true;
            RangeEnhancerQtyVisibility = true;
            SkillEnhancerQtyVisibility = true;
        }

        protected override void Init()
        {
            NomFormEnabled = false;
            SearchModes = repos.SearchModesDto.GetAll().ToList();
            Finders = repos.FindersDto.GetAll().ToList();
            FinderAmplifiers = repos.FinderAmplifiersDto.GetAll().ToList();
        }

        // Affichage de la liste des searchMode ds le combobox
        public ICollection<SearchModeDto> SearchModes { get; set; }

        // Affichage de la liste des finder ds le combobox
        public ICollection<FinderDto> Finders { get; set; }

        // Affichage de la liste des finderamplifier ds le combobox
        public ICollection<FinderAmplifierDto> FinderAmplifiers { get; set; }
    }
}
