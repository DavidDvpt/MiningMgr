using System.Linq;
using WpfApp.Model.Poco;

namespace WpfApp.ViewModel
{
    public class EnhancerManagerViewModel : ManagerViewModel<EnhancerPoco>
    {
        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            ModeleNomVisibility = true;
            IsActiveVisibility = true;
        }

        protected override void Init()
        {
            DataGridItemSource = repos.EnhancersPoco.GetAll().ToList();
        }
    }
}
