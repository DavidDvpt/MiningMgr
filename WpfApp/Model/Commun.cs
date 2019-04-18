using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WpfApp.AttributValidation;

namespace WpfApp.Model
{
    [Table("Commun")]
    public abstract class Commun : BindableBase
    {
        public Commun()
        {
            IsActive = true;
        }

        [Key]
        [Required]
        public int Id
        {
            get { return GetValue(() => Id); }
            set
            {
                if (value != Id)
                {
                    SetValue(() => Id, value);
                }
            }
        }

        [Required(ErrorMessage = "Le Nom est requis")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50, ErrorMessage = "La longueur maximum est de 50")]
        [Index(IsUnique = true)]
        [Unique(ErrorMessage ="Ce nom est déjà utilisé")]
        public string Nom
        {
            get { return GetValue(() => Nom); }
            set
            {
                if (Nom != value)
                {
                    SetValue(() => Nom, value); 
                } }
        }

        public bool IsActive
        {
            get { return GetValue(() => IsActive); }
            set
            {
                if (value != IsActive)
                {
                    SetValue(() => IsActive, value);
                }
            }
        }
    }
}
