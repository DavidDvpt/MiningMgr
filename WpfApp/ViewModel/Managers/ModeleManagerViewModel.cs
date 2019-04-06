using System.Collections.Generic;
using System.Linq;
using WpfApp.Model.Poco;

namespace WpfApp.ViewModel
{
    public class ModeleManagerViewModel : ManagerViewModel<ModelePoco>
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
            DataGridItemSource = repos.ModelesPoco.GetAll().ToList();
        }

        public ICollection<CategoriePoco> CategoriesPoco
            => repos.CategoriesPoco.GetAll().ToList();
    }
}
