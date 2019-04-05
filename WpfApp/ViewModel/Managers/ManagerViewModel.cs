using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public abstract class ManagerViewModel<T> : BaseViewModel
        where T : class
    {
        private T _dgSelectedItem;
        private ICollection<T> _dataGridItemSources;

        public ManagerViewModel()
        {
            ColumnInit();
        }

        protected abstract void ColumnInit();

        public ICollection<T> DataGridItemSource
        {
            get { return _dataGridItemSources; }
            set
            {
                if(_dataGridItemSources != value)
                {
                    _dataGridItemSources = value;
                }
            }
        }

        #region DataGridColumnVisibility
        // Commun, Categorie, Planet
        public bool IdVisibility { get; set; } = false;
        public bool NomVisibility { get; set; } = false;
        public bool IsActiveVisibility { get; set; } = false;

        // Modele
        public bool CategorieNomVisibility { get; set; } = false;

        // InWorld
        public bool ValueVisibility { get; set; } = false;
        public bool ModeleNomVisibility { get; set; } = false;

        // Unstackable
        public bool IsLimitedVisibility { get; set; } = false;
        public bool DecayVisibility { get; set; } = false;
        public bool CodeMinVisibility { get; set; } = false;

        // Tool
        public bool UsePerMinVisibility { get; set; } = false;

        //Depth
        public bool DepthVisibility { get; set; } = false;
        public bool RangeVisibility { get; set; } = false;

        // Excavator
        public bool EfficientyVisibility { get; set; } = false;

        // Accessoires
        // Finder Amplifier
        public bool CoefficientVisibility { get; set; } = false;

        // Enhancer
        public bool SlotVisibility { get; set; } = false;
        public bool BonusValue1Visibility { get; set; } = false;
        public bool BonusValue2Visibility { get; set; } = false;

        // SearchMode
        public bool AbbrevVisibility { get; set; } = false;
        public bool MultiplicateurVisibility { get; set; } = false;

        // Setup
        public bool SearchModeVisibility { get; set; } = false;
        public bool FinderVisibility { get; set; } = false;
        public bool FinderAmplifierVisibility { get; set; } = false;
        public bool DepthEnhancerQtyVisibility { get; set; } = false;
        public bool RangeEnhancerQtyVisibility { get; set; } = false;
        public bool SkillEnhancerQtyVisibility { get; set; } = false;
        #endregion

        public T DgSelectedItem
        {
            get => _dgSelectedItem;
            set
            {
                if (_dgSelectedItem != value)
                {
                    _dgSelectedItem = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
