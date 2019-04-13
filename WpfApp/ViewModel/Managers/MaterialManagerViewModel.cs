using System.Collections.Generic;
using System.Linq;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    public class MaterialManagerViewModel : ManagerViewModel<MaterialDto>
    {
        private ModeleDto _selectedModele;
        public ICollection<ModeleDto> Modeles { get; set; }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            IsActiveVisibility = true;
            ValueVisibility = true;

            CbxModelesChoiceVisibility = true;
        }

        protected override void Init()
        {
            Modeles = repos.ModelesDto.GetByCategorieName("Material").ToList();
        }

        public ModeleDto SelectedModele
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
            DataGridItemSource = repos.MaterialsDto.GetByModeleId(SelectedModele.Id);
        }

        protected override void CreateItem()
        {
            ItemForm = new MaterialDto { Modele = SelectedModele };
            NomFormEnabled = true;
        }

    }

    
}
