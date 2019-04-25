using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp.Commands;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class StockViewModel : BaseViewModel
    {
        #region Champs

        private string _dgItemSourceParam;

        #endregion

        #region Constructeurs et initialisation

        public StockViewModel(string param)
        {
            _dgItemSourceParam = param;
        }

        protected override void Init()
        {
            Modeles = repos.Modeles.GetByCategorieName("Material").ToList();
            AchatVisibility = false;
            CancelAchatCommand = new RelayCommand(CancelAchatExecute, CancelAchatCanExecute);
            ValidateAchatCommand = new RelayCommand(ValidateAchatExecute, ValidateAchatCanExecute);
        }

        #endregion

        #region Commands

        public RelayCommand CancelAchatCommand { get; set; }
        public RelayCommand ValidateAchatCommand { get; set; }

        #region Execute

        public void ValidateAchatExecute(object param)
        {
            repos.TradeMaterials.Add(TradeMaterial);
            DgSelectedItem.Quantity -= TradeMaterial.Quantity;    
            MessageBox.Show("L'achat a bien été enregistré", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            TradeMaterial = null;
            DgSelectedItem = null;
        }

        public void CancelAchatExecute(object param)
        {
            TradeMaterial = null;
            DgSelectedItem = null;
        }

        #endregion

        #region CanExecute

        public bool ValidateAchatCanExecute(object param)
        {
            if (Errors == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CancelAchatCanExecute(object param)
        {
            return true;
        }

        #endregion

        #endregion

        #region Gestion du modele à afficher

        public ICollection<Modele> Modeles { get; set; }

        public Modele SelectedModele
        {
            get { return GetValue(() => SelectedModele); }
            set
            {
                if (value != SelectedModele)
                {
                    SetValue(() => SelectedModele, value);
                    ItemSourceUpdated();
                }
            }
        }

        #endregion

        #region DataGrid

        public ICollection<StockMaterial> DataGridItemSource
        {
            get { return GetValue(() => DataGridItemSource); }
            set
            {
                if (value != DataGridItemSource)
                {
                    SetValue(() => DataGridItemSource, value);
                }
            }
        }

        /// <summary>
        /// Modifie la source des que le modele change
        /// </summary>
        private void ItemSourceUpdated()
        {
            DataGridItemSource = repos.StockMaterials.GetAll().Where(x=>x.ModeleId == SelectedModele.Id).ToList();
        }

        public StockMaterial DgSelectedItem
        {
            get { return GetValue(() => DgSelectedItem); }
            set
            {
                if (DgSelectedItem != value)
                {
                    SetValue(() => DgSelectedItem, value);
                    CreateTradeMaterial();
                    AchatVisibility = DgSelectedItem != null ? true : false;
                }
            }
        }

        #endregion

        public TradeMaterial TradeMaterial
        {
            get { return GetValue(() => TradeMaterial); }
            set
            {
                if (TradeMaterial != value)
                {
                    SetValue(() => TradeMaterial, value);

                }
            }
        }

        private void CreateTradeMaterial()
        {
            if (DgSelectedItem != null)
            {
                TradeMaterial = new TradeMaterial()
                {
                    Material = DgSelectedItem,
                    Quantity = DgSelectedItem.Quantity,
                    State = repos.TradeStates.GetByNom("En Cours")
                };
            }
            
        }
        
        public bool AchatVisibility
        {
            get { return GetValue(() => AchatVisibility); }
            set
            {
                if (AchatVisibility != value)
                {
                    SetValue(() => AchatVisibility, value);
                }
            }
        }
    }
}
