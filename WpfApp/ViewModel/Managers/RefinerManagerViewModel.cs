using System.Linq;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class RefinerManagerViewModel : ManagerViewModel<Refiner>
    {
        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            DecayVisibility = true;
            UsePerMinVisibility = true;
            IsLimitedVisibility = true;
            IsActiveVisibility = true;
            CodeVisibility = true;
        }

        protected override void Init()
        {
            //DataGridItemSource = repos.RefinersDto.GetAll().ToList();
        }

    }
}
