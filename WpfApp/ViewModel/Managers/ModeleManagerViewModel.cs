using System.Collections.Generic;
using System.Linq;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    public class ModeleManagerViewModel : ManagerViewModel<ModeleDto>
    {
        public ModeleManagerViewModel()
        {

        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            CategorieNomVisibility = true;
            IsActiveVisibility = true;
        }

        protected override void Init()
        {
            DataGridItemSource = repos.ModelesDto.GetAll().ToList();
            Categories = repos.CategoriesDto.GetAll().ToList();
        }

        protected override void ValiderItem()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<CategorieDto> Categories { get; set; }
    }
}
