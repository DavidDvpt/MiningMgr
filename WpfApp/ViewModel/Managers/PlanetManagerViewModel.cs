using System.Linq;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    public class PlanetManagerViewModel : ManagerViewModel<PlanetDto>
    {
        protected override void Init()
        {
            DataGridItemSource = repos.PlanetsDto.GetAll().ToList();
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            IsActiveVisibility = true;
        }

        protected override void ValiderItem()
        {
            throw new System.NotImplementedException();
        }
    }
}
