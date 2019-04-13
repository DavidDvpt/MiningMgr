using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        protected override void Init()
        {
            Modeles = repos.ModelesDto.GetAll().ToList();
        }

        public ModeleDto SelectedModele
        {
            get { return _selectedModele; }
            set
            {
                _selectedModele = value;
                ItemSourceChanged();
                OnPropertyChanged();
            }
        }

        private void ItemSourceChanged()
        {
            DataGridItemSource = repos.MaterialsDto.GetByModeleId(SelectedModele.Id);
        }

        protected override void CreateItem()
        {
            ItemForm = new MaterialDto();
            ItemForm.Modele = SelectedModele;
        }

    }

    
}
