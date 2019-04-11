using System.Linq;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    public class FinderManagerViewModel : ManagerViewModel<FinderDto>
    {
        public FinderManagerViewModel()
        {
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            DecayVisibility = true;
            UsePerMinVisibility = true;
            IsLimitedVisibility = true;
            IsActiveVisibility = true;
            DepthVisibility = true;
            RangeVisibility = true;
        }

        protected override void Init()
        {
            //DataGridItemSource = repos.FindersDto.GetAll().ToList();
        }

    }
}
