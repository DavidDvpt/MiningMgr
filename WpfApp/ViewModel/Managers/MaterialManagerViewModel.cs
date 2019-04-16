using System.Collections.Generic;
using System.Linq;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class MaterialManagerViewModel : ManagerViewModel<Material>
    {
        private Modele _selectedModele;
        public ICollection<Modele> Modeles { get; set; }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            IsActiveVisibility = true;
            ValueVisibility = true;

            CbxModelesChoiceVisibility = true;
        }

        protected override void Init()
        {
            Modeles = repos.Modeles.GetByCategorieName("Material").ToList();
        }

        public Modele SelectedModele
        {
            get { return _selectedModele; }
            set
            {
                _selectedModele = value;
                ItemSourceUpdated();
                OnPropertyChanged();
            }
        }

        protected override void ItemSourceUpdated()
        {
            DataGridItemSource = repos.Materials.GetByModeleId(SelectedModele.Id);
        }

        protected override void CreateItem()
        {
            ItemForm = new Material { Modele = SelectedModele };
            NomFormEnabled = true;
        }

    }

    
}
