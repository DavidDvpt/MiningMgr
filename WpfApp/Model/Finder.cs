using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Finder")]
    public class Finder : Tool
    {
        private decimal _depth;
        private decimal _range;
        private short _basePecSearch;

        public decimal Depth
        {
            get => _depth;
            set
            {
                _depth = value;
                NotifyPropertyChanged();
            }
        }

        public decimal Range
        {
            get => _range;
            set
            {
                _range = value;
                NotifyPropertyChanged();
            }
        }

        public short BasePecSearch
        {
            get => _basePecSearch;
            set
            {
                _basePecSearch = value;
                NotifyPropertyChanged();
            }
        }
    }
}
