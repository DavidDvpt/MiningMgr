using System.Collections.Generic;
using System.Linq;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class ModeleManagerViewModel : ManagerViewModel<Modele>
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
            Categories = repos.Categories.GetAll().ToList();
        }

        public ICollection<Categorie> Categories { get; set; }
    }
}
