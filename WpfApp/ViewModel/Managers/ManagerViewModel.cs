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
        private ICollection<T> _dataGridItemSources;

        public ManagerViewModel()
        {
            DataGridComumnVisibilityInit();
        }

        private void DataGridComumnVisibilityInit()
        {
            IdVisibility = false;
            NomVisibility = false;
            IsActiveVisibility = false;

            CategorieNomVisibility = false;
            DepthVisibility = false;
            RangeVisibility = false;
            UsePerMinVisibility = false;
        }

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
        public bool IdVisibility { get; set; }
        public bool NomVisibility { get; set; }
        public bool IsActiveVisibility { get; set; }

        // Modele
        public bool CategorieNomVisibility { get; set; }

        // InWorld
        public bool ValueMinVisibility { get; set; }

        public bool UsePerMinVisibility { get; set; }





        public bool DepthVisibility { get; set; }

        public bool RangeVisibility { get; set; }

        public bool SlotVisibility { get; set; }

        public bool BonusValue1Visibility { get; set; }

        public bool BonusValue2Visibility { get; set; }

        public bool EfficientyVisibility { get; set; }

        public bool CoefficientVisibility { get; set; }

        public bool ValueVisibility { get; set; }

        public bool AbbrevVisibility { get; set; }

        public bool MultiplicateurVisibility { get; set; }

        public bool SearchModeVisibility { get; set; }

        public bool FinderVisibility { get; set; }

        public bool FinderAmplifierVisibility { get; set; }

        public bool IsLimitedVisibility { get; set; }

        public bool DecayVisibility { get; set; }

        public bool CodeVisibility { get; set; }
        #endregion




    }
}
