using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class FinderManagerViewModel : UnstackableManagerViewModel<Finder>
    {
        #region Constructeurs et initialisations

        public FinderManagerViewModel()
        {
            _nomUnstackable = "Finder";
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
            ModeleNomVisibility = true;
        }

        #endregion
    }
}
