using WpfApp.Model.Dto;

namespace WpfApp.Model.Poco
{
    public abstract class CommunPoco<TDto> : BasePoco<TDto>
        where TDto : CommunDto, new()
    {
        public int Id
        {
            get => _Dto.Id;
            set
            {
                if (value != _Dto.Id)
                {
                    _Dto.Id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Nom
        {
            get => _Dto.Nom;
            set
            {
                if (value != _Dto.Nom)
                {
                    _Dto.Nom = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsActive
        {
            get => _Dto.IsActive;
            set
            {
                if (value != _Dto.IsActive)
                {
                    _Dto.IsActive = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
