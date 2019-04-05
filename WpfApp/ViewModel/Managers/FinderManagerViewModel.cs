using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

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
            DataGridItemSource = repos.Finders.GetAll().ToList();
        }

    }
}
