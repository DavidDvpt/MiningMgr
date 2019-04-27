using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("SearchMode")]
    public class SearchMode : Commun
    {
        [MaxLength(3)]
        public string Abbrev { get; set; }

        [Required]
        public decimal Multiplicateur { get; set; } = 1;
    }
}
