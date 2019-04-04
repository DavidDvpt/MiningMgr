using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class FinderManagerViewModel : ManagerViewModel<FinderModel>
    {
        public FinderManagerViewModel()
        {
            FinderColumnInit();
        }
        protected override void Init()
        {
            DataGridItemSource = repos.Finders.GetAll().ToList();
        }

        private void FinderColumnInit()
        {
            NomVisibility = true;
            DepthVisibility = true;
            RangeVisibility = true;
        }
    }
}
