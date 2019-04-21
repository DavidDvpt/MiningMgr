using System.Collections.Generic;
using System.Linq;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class SetupManagerViewModel : ManagerViewModel<Setup>
    {
        #region Constructeur et initialisations

        public SetupManagerViewModel()
        {
            NomFormEnabled = false;
        }

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
            SearchModes = repos.SearchModes.GetAll().ToList();
            Finders = repos.Finders.GetAll().ToList();
            FinderAmplifiers = repos.FinderAmplifiers.GetAll().ToList();
        }

        #endregion

        public override void CreateExecute(object param)
        {
            ItemForm = new Setup();
        }

        // Affichage de la liste des searchMode ds le combobox
        public ICollection<SearchMode> SearchModes { get; set; }

        // Affichage de la liste des finder ds le combobox
        public ICollection<Finder> Finders { get; set; }

        // Affichage de la liste des finderamplifier ds le combobox
        public ICollection<FinderAmplifier> FinderAmplifiers { get; set; }
    }
}
