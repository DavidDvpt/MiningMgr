using System.Collections.Generic;
using System.Linq;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class StockViewModel : BaseViewModel
    {
        #region Champs

        private string _dgItemSourceParam;
        private string _tradeMaterial;

        #endregion

        #region Constructeurs et initialisation

        public StockViewModel(string param)
        {
            _dgItemSourceParam = param;
        }

        protected override void Init()
        {
            Modeles = repos.Modeles.GetByCategorieName("Material").ToList();
        }

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
            TradeMaterial = new TradeMaterial()
            {
                Material = DgSelectedItem,
                Quantity = DgSelectedItem.Quantity,
                State = repos.TradeStates.GetByNom("En Cours")
            };
        }


    }
}
