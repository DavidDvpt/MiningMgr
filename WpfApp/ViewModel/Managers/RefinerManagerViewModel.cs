using System.Linq;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    public class RefinerManagerViewModel : ManagerViewModel<RefinerDto>
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
