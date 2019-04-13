using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("InWorld")]
    public abstract class InWorldDto : CommunDto
    {
        public InWorldDto()
        {

        }

        #region SiPoco
        //[Required]
        //public decimal Value { get; set; }

        //public int ModeleId { get; set; }

        //[ForeignKey("ModeleId")]
        //public virtual ModeleDto Modele { get; set; }
        #endregion

        #region SiDto
        [Required]
        private decimal _value;
        private int _modeleId;
        private ModeleDto _modele;

        public decimal Value
        {
            get => _value;
            set
            {
                _value = value;
                NotifyPropertyChanged();
            }
        }

        public int ModeleId
        {
            get => _modeleId;
            set
            {
                _modeleId = value;
                NotifyPropertyChanged();
            }
        }

        [ForeignKey("ModeleId")]
        public virtual ModeleDto Modele
        {
            get => _modele;
            set
            {
                _modele = value;
                ModeleId = value.Id;
                NotifyPropertyChanged();
            }
        }
        #endregion
    }
}
