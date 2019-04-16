using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class EnhancerManagerViewModel : ManagerViewModel<Enhancer>
    {
        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            ModeleNomVisibility = true;
            IsActiveVisibility = true;
            SlotVisibility = true;
            BonusValue1Visibility = true;
            BonusValue2Visibility = true;
        }

        protected override void Init()
        {
        }

    }
}
