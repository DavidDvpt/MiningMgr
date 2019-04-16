using WpfApp.Model;

namespace WpfApp.ViewModel
{
    // heritage :
    // BlindableBase : Contient le InotifyChanged et la methode SetProperty
    // BaseViewModel : contient l'instanciation des repositoris repos
    // ManagerViewModel<T> : contient la source generique du datagrid
    public class CategorieManagerViewModel : ManagerViewModel<Categorie>
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
            //DataGridItemSource = repos.CategoriesDto.GetAll().ToList();         
        }
    }
}
