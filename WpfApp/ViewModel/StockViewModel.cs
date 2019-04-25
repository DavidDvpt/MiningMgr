using System.Collections.Generic;
using System.Linq;
using WpfApp.Model;
using WpfApp.Model.Dto.Interfaces;

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
            SelectedModele = repos.Modeles.GetByNom("Ore");
            FormulaireAchat = new FormulaireAchatViewModel();
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

        public ICollection<Material> DataGridItemSource
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

        private void ItemSourceUpdated()
        {
            DataGridItemSource = repos.Materials.GetByModeleId(SelectedModele.Id);
        }

        #endregion

        public BindableBase FormulaireAchat
        {
            get { return GetValue(() => FormulaireAchat); }
            set
            {
                if (value != FormulaireAchat)
                {
                    SetValue(() => FormulaireAchat, value);
                }
            }
        }
    }
}
