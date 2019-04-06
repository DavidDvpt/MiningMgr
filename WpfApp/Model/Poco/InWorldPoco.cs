using WpfApp.Model.Dto;
using WpfApp.Model.Dto.Interfaces;

namespace WpfApp.Model.Poco
{
    public class InWorldPoco<TDto> : CommunPoco<TDto>
        where TDto : InWorldDto
    {
        public decimal Value
        {
            get => _Dto.Value;
            set
            {
                _Dto.Value = value;
                NotifyPropertyChanged();
            }
        }

        public int ModeleId
        {
            get => _Dto.ModeleId;
            set
            {
                _Dto.ModeleId = value;
                NotifyPropertyChanged();
            }
        }

        public virtual ModeleDto Modele
        {
            get => _Dto.Modele;
            set
            {
                _Dto.Modele = value;
                NotifyPropertyChanged();
            }
        }
    }
}
