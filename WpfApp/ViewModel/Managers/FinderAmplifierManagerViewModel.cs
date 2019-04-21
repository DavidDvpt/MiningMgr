using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class FinderAmplifierManagerViewModel : UnstackableManagerViewModel<FinderAmplifier>
    {
        #region Constructeurs et initialisations

        public FinderAmplifierManagerViewModel()
        {
            _nomUnstackable = "FinderAmplifier";
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            DecayVisibility = true;
            CoefficientVisibility = true;
            IsLimitedVisibility = true;
            IsActiveVisibility = true;
            CodeVisibility = true;
            ModeleNomVisibility = true;
        }

        #endregion
    }
}
