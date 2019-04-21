using System.Linq;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class RefinerManagerViewModel : UnstackableManagerViewModel<Refiner>
    {
        #region Constructeurs et initialisation

        public RefinerManagerViewModel()
        {
            _nomUnstackable = "Refiner";
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            DecayVisibility = true;
            UsePerMinVisibility = true;
            IsLimitedVisibility = true;
            IsActiveVisibility = true;
            CodeVisibility = true;
            ModeleNomVisibility = true;
        }

        #endregion

    }
}
