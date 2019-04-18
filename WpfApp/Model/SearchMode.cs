using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("SearchMode")]
    public class SearchMode : Commun
    {
        public SearchMode()
        {
            Multiplicateur = 1;
        }

        [MaxLength(3, ErrorMessage = "L'abbreviation peut contenir que 3 lettres")]
        public string Abbrev
        {
            get { return GetValue(() => Abbrev); }
            set
            {
                if (value != Abbrev)
                {
                    SetValue(() => Abbrev, value);
                }
            }
        }

        [Range(1, 6, ErrorMessage = "Le multiplicateur doit être compris entre 1 et 6")]
        public decimal Multiplicateur
        {
            get { return GetValue(() => Multiplicateur); }
            set
            {
                if (value != Multiplicateur)
                {
                    SetValue(() => Multiplicateur, value);
                }
            }
        }
    }
}
