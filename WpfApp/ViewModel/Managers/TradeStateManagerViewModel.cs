using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class TradeStateManagerViewModel : ManagerViewModel<TradeState>
    {
        public TradeStateManagerViewModel()
        {

        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            IsActiveVisibility = true;
        }

        protected override void Init()
        {
            
        }
    }
}
