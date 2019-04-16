using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("SearchMode")]
    public class SearchMode : Commun
    {
        private string _abbrev;
        private decimal _multiplicateur;

        public string Abbrev
        {
            get => _abbrev;
            set
            {
                _abbrev = value;
                NotifyPropertyChanged();
            }
        }

        public decimal Multiplicateur
        {
            get => _multiplicateur;
            set
            {
                _multiplicateur = value;
                NotifyPropertyChanged();
            }
        }
    }
}
