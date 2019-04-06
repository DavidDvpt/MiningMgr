using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp.Model.Poco.Interfaces;

namespace WpfApp.Model.Poco
{
    public abstract class BasePoco<TDto> : IPoco<TDto>, INotifyPropertyChanged
        where TDto : class, new()
    {
        protected TDto _Dto;

        public BasePoco()
        {
            _Dto = new TDto();
        }

        public BasePoco(TDto dto)
        {
            if (dto != null)
            {
                SetDto(dto);
            }
            _Dto = new TDto(); 
        }

        public void SetDto(TDto entity)
        {
            if (entity != null) _Dto = entity;
        }

        public TDto GetDto()
        {
            return _Dto;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
