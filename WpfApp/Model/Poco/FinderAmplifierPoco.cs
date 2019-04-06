using WpfApp.Model.Dto;

namespace WpfApp.Model.Poco
{
    public class FinderAmplifierPoco : UnstackablePoco<FinderAmplifierDto>
    {
        public decimal Coefficient
        {
            get => _Dto.Coefficient;
            set
            {
                _Dto.Coefficient = value;
                NotifyPropertyChanged();
            }
        }
    }
}
