using WpfApp.Model.Dto;

namespace WpfApp.Model.Poco
{
    public class FinderPoco : ToolPoco<FinderDto>
    {
        public decimal Depth
        {
            get => _Dto.Depth;
            set
            {
                _Dto.Depth = value;
                NotifyPropertyChanged();
            }
        }

        public decimal Range
        {
            get => _Dto.Range;
            set
            {
                _Dto.Range = value;
                NotifyPropertyChanged();
            }
        }

        public short BasePecSearch
        {
            get => _Dto.BasePecSearch;
            set
            {
                _Dto.UsePerMin = BasePecSearch;
                NotifyPropertyChanged();
            }
        }
    }
}
