using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("SearchMode")]
    public class SearchModeDto : CommunDto
    {
        public string Abbrev { get; set; }

        public decimal Multiplicateur { get; set; }
    }
}
