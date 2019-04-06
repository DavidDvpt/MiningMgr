using System.Linq;
using WpfApp.Model.Poco;

namespace WpfApp.ViewModel
{
    public class FinderManagerViewModel : ManagerViewModel<FinderPoco>
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
            DataGridItemSource = repos.FindersPoco.GetAll().ToList();
        }

    }
}
