using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Commun")]
    public abstract class Commun : BaseModel
    {
        private int _id;
        private string _nom;
        private bool _isActive = true;

        [Key]
        [Required]
        public int Id
        {
            get => _id;
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required(ErrorMessage = "Le Nom est requis")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50, ErrorMessage = "La longueur maximum est de 50")]
        [Index(IsUnique = true)]
        public string Nom
        {
            get => _nom;
            set
            {
                if (value != _nom)
                {
                    _nom = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (value != _isActive)
                {
                    _isActive = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
