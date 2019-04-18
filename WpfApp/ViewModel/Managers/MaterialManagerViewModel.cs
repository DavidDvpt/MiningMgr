using System.Collections.Generic;
using System.Linq;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class MaterialManagerViewModel : ManagerViewModel<Material>
    {
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
            get { return GetValue(() => SelectedModele); }
            set
            {
                if (SelectedModele != value)
                {
                    SetValue(() => SelectedModele, value);
                    ItemSourceUpdated();
                }
            }
        }

        protected void ItemSourceUpdated()
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
