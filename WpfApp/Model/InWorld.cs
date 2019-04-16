using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("InWorld")]
    public abstract class InWorld : Commun
    {
        [Required]
        private decimal _value = 0;
        private int _modeleId;
        private Modele _modele;

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
        public virtual Modele Modele
        {
            get => _modele;
            set
            {
                _modele = value;
                if (value != null)
                {
                    
                    ModeleId = value.Id;
                    NotifyPropertyChanged(); 
                }
            }
        }
    }
}
