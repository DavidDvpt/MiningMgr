using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Finder")]
    public class Finder : Tool
    {
        public decimal Depth { get; set; }

        public decimal Range { get; set; }

        public short BasePecSearch { get; set; }
    }
}
