using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class PlanetManagerViewModel : ManagerViewModel<Planet>
    {
        protected override void Init()
        {
            //DataGridItemSource = repos.PlanetsDto.GetAll().ToList();
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            IsActiveVisibility = true;
        }

    }
}
