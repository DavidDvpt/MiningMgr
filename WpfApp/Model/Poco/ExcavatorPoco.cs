using WpfApp.Model.Dto;

namespace WpfApp.Model.Poco
{
    public class ExcavatorPoco : ToolPoco<ExcavatorDto>
    {

        public decimal Efficienty
        {
            get => _Dto.Efficienty;
            set
            {
                _Dto.Efficienty = value;
                NotifyPropertyChanged();
            }
        }
    }
}
