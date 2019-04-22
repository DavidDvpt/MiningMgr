using System.Collections.Generic;
using System.Linq;
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

                }
            }
        }

        #endregion
        // Ajouter le tradematerial comme formulaire
        public decimal TtCost
        {
            get { return GetValue(() => TtCost); }
            set
            {
                if (value != TtCost)
                {
                    SetValue(() => TtCost, value);
                }
            }
        }

        private void CalculAchat()
        {
            TtCost = DgSelectedItem.Quantity * DgSelectedItem.Value;
        }
    }
}
