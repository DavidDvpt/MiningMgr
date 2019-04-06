using WpfApp.Model.Dto;

namespace WpfApp.Model.Poco
{
    public abstract class UnstackablePoco<TDto> : InWorldPoco<TDto>
        where TDto : UnstackableDto
    {
        public bool IsLimited
        {
            get => _Dto.IsLimited;
            set
            {
                _Dto.IsLimited = value;
                NotifyPropertyChanged();
            }
        }

        public decimal Decay
        {
            get => _Dto.Decay;
            set
            {
                _Dto.Decay = value;
                NotifyPropertyChanged();
            }
        }

        public string Code
        {
            get => _Dto.Code;
            set
            {
                _Dto.Code = value;
                NotifyPropertyChanged();
            }
        }
    }
}
