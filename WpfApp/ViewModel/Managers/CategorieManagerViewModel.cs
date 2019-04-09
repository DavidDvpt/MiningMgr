using System.Linq;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    // heritage :
    // BlindableBase : Contient le InotifyChanged et la methode SetProperty
    // BaseViewModel : contient l'instanciation des repositoris repos
    // ManagerViewModel<T> : contient la source generique du datagrid
    public class CategorieManagerViewModel : ManagerViewModel<CategorieDto>
    {
        public CategorieManagerViewModel() : base()
        {

        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            IsActiveVisibility = true;
        }

        protected override void Init()
        {
            DataGridItemSource = repos.CategoriesDto.GetAll().ToList();         
        }

        protected override void ValiderItem()
        {
            if (ItemForm.Id > 0)
            {
                repos.CategoriesDto.Update(ItemForm);
            }
            else
            {
                repos.CategoriesDto.Add(ItemForm);
                DataGridItemSource = repos.CategoriesDto.GetAll().ToList();
            }

            
        }
    }
}
