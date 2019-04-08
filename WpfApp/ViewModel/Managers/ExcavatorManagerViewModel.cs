using System.Linq;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    public class ExcavatorManagerViewModel : ManagerViewModel<ExcavatorDto>
    {
        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            DecayVisibility = true;
            UsePerMinVisibility = true;
            IsLimitedVisibility = true;
            IsActiveVisibility = true;
            EfficientyVisibility = true;
        }

        protected override void Init()
        {
            DataGridItemSource = repos.ExcavatorsDto.GetAll().ToList();
        }


    }
}
