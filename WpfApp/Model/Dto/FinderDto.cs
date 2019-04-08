using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Finder")]
    public class FinderDto : ToolDto
    {
        #region SiPoco
        //public decimal Depth { get; set; }

        //public decimal Range { get; set; }

        //public short BasePecSearch { get; set; }
        #endregion

        #region SiDto
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
        #endregion
    }
}
