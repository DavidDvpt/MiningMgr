using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

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
            DataGridItemSource = repos.FinderAmplifiers.GetAll().ToList();
        }
    }
}
