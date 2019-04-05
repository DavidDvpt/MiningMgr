using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Finder")]
    public class FinderDto : ToolDto
    {
        public decimal Depth { get; set; }

        public decimal Range { get; set; }

        public short BasePecSearch { get; set; }
    }
}
