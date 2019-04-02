using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("SearchMode")]
    public class SearchModeModel : CommunModel
    {
        public string Abbrev { get; set; }

        public decimal Multiplicateur { get; set; }
    }
}
