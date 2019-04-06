using WpfApp.Model.Dto;

namespace WpfApp.Model.Poco
{
    public abstract class ToolPoco<TDto> : UnstackablePoco<TDto>
        where TDto : ToolDto, new()
    {
        public short UsePerMin
        {
            get => _Dto.UsePerMin;
            set
            {
                _Dto.UsePerMin = value;
                NotifyPropertyChanged();
            }
        }
    }
}
