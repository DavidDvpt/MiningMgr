using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class ExcavatorManagerViewModel : UnstackableManagerViewModel<Excavator>
    {
        #region Constructeur et initialisations

        public ExcavatorManagerViewModel()
        {
            _nomUnstackable = "Excavator";
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            DecayVisibility = true;
            UsePerMinVisibility = true;
            IsLimitedVisibility = true;
            IsActiveVisibility = true;
            EfficientyVisibility = true;
            CodeVisibility = true;
            ModeleNomVisibility = true;
        }

        #endregion
    }
}
