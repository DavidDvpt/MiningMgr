using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WpfApp.Model
{
    [Table("Commun")]
    public abstract class CommunModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string _nom;
        private bool _isActive = true;

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50,ErrorMessage = "La longueur maximum est de 50")]
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

        [Required]
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
