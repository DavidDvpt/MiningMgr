using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("FinderAmplifier")]
    public class FinderAmplifierDto : UnstackableDto
    {
        #region SiPoco
        //public decimal Coefficient { get; set; }
        #endregion

        #region SiDto
        private decimal _coefficient;

        public decimal Coefficient
        {
            get => _coefficient;
            set
            {
                _coefficient = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
    }
}
