using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class ExcavatorManagerViewModel : ManagerViewModel<Excavator>
    {
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
        }

        protected override void Init()
        {
            //DataGridItemSource = repos.ExcavatorsDto.GetAll().ToList();
        }

    }
}
