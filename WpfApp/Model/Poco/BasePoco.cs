using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp.Model.Poco.Interfaces;

namespace WpfApp.Model.Poco
{
    public abstract class BasePoco<T> : IPoco<T>, INotifyPropertyChanged
    {
        protected T _Dto;

        public BasePoco()
        {
            _Dto = new T();
        }

        public BasePoco(T dto)
        {
            if (dto != null)
            {
                SetDto(dto);
            }
            _Dto = new T(); 
        }

        public void SetDto(T entity)
        {
            if (entity != null) _Dto = entity;
        }

        public T GetDto()
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
