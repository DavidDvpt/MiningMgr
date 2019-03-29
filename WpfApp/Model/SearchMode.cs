using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("SearchMode")]
    public class SearchMode : Commun
    {
        public string Abbrev { get; set; }

        public decimal Multiplicateur { get; set; }
    }
}
