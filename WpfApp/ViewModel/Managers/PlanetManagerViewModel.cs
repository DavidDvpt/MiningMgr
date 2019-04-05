using System.Linq;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class PlanetManagerViewModel : ManagerViewModel<PlanetModel>
    {
        protected override void Init()
        {
            DataGridItemSource = repos.Planets.GetAll().ToList();
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            IsActiveVisibility = true;
        }
    }
}
