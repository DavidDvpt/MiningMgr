using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class FinderManagerViewModel : ManagerViewModel<Finder>
    {
        public FinderManagerViewModel()
        {
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            CodeVisibility = true;
            IsActiveVisibility = true;
            IsLimitedVisibility = true;
            ValueVisibility = true;
            DecayVisibility = true;
            UsePerMinVisibility = true;
            DepthVisibility = true;
            RangeVisibility = true;
            BasePecSearchVisibility = true;
        }

        protected override void Init()
        {
            //DataGridItemSource = repos.FindersDto.GetAll().ToList();
        }

    }
}
