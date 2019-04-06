using System.Linq;
using WpfApp.Model.Poco;

namespace WpfApp.ViewModel
{
    public class PlanetManagerViewModel : ManagerViewModel<PlanetPoco>
    {
        protected override void Init()
        {
            DataGridItemSource = repos.PlanetsPoco.GetAll().ToList();
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            IsActiveVisibility = true;
        }
    }
}
