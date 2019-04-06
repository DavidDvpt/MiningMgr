using WpfApp.Model.Dto;

namespace WpfApp.Model.Poco
{
    public class SearchModePoco : CommunPoco<SearchModeDto>
    {
        public string Abbrev
        {
            get => _Dto.Abbrev;
            set
            {
                if (value != _Dto.Abbrev)
                {
                    _Dto.Abbrev = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal Multiplicateur
        {
            get => _Dto.Multiplicateur;
            set
            {
                if (value != _Dto.Multiplicateur)
                {
                    _Dto.Multiplicateur = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
