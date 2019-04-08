using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("SearchMode")]
    public class SearchModeDto : CommunDto
    {
        #region SiPoco
        //public string Abbrev { get; set; }

        //public decimal Multiplicateur { get; set; }
        #endregion

        #region SiDto
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
        #endregion
    }
}
