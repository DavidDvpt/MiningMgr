using System.Linq;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    public class FinderAmplifierManagerViewModel : ManagerViewModel<FinderAmplifierDto>
    {
        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            DecayVisibility = true;
            CoefficientVisibility = true;
            IsLimitedVisibility = true;
            IsActiveVisibility = true;
        }

        protected override void Init()
        {
            //DataGridItemSource = repos.FinderAmplifiersDto.GetAll().ToList();
        }

    }
}
