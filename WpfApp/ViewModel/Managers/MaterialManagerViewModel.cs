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
            RefinedToVisibility = true;
            QuantityVisibility = true;

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

        public void ItemSourceUpdated()
        {
            DataGridItemSource = repos.Materials.GetByModeleId(SelectedModele.Id);
        }

        public override void CreateExecute(object param)
        {
            ItemForm = new Material { Modele = SelectedModele };
            NomFormEnabled = true;
        }

    }

    
}
