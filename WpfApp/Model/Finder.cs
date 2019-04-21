using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Finder")]
    public class Finder : Tool
    {
        public Finder()
        {
            Depth = 0;
            Range = 0;
            BasePecSearch = 0;
        }

        [Range(0, 1000, ErrorMessage = "La profondeur doit être comprise entre 0 et 1000")]
        public decimal Depth
        {
            get { return GetValue(() => Depth); }
            set
            {
                if (value != Depth)
                {
                    SetValue(() => Depth, value);
                }
            }
        }

        [Range(0, 60, ErrorMessage = "La profondeur doit être comprise entre 0 et 1000")]
        public decimal Range
        {
            get { return GetValue(() => Range); }
            set
            {
                if (value != Range)
                {
                    SetValue(() => Range, value);
                }
            }
        }

        public short BasePecSearch
        {
            get { return GetValue(() => BasePecSearch); }
            set
            {
                if (value != BasePecSearch)
                {
                    SetValue(() => BasePecSearch, value);
                }
            }
        }
    }
}
