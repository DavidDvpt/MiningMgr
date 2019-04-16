using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Finder")]
    public class Finder : Tool
    {
        private decimal _depth = 0;
        private decimal _range = 0;
        private short _basePecSearch = 0;

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
