using System.Linq;
using WpfApp.Model.Poco;

namespace WpfApp.ViewModel
{
    public class FinderAmplifierManagerViewModel : ManagerViewModel<FinderAmplifierPoco>
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
            DataGridItemSource = repos.FinderAmplifiersPoco.GetAll().ToList();
        }
    }
}
