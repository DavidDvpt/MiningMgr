using System.Linq;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    public class PlanetManagerViewModel : ManagerViewModel<PlanetDto>
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
