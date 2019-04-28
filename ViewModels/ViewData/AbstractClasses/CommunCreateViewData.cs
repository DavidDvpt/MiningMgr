using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public abstract class CommunCreateViewData : BindableBase
    {
        [Required(ErrorMessage = "Le Nom est requis")]
        [MaxLength(50, ErrorMessage = "La longueur maximum est de 50")]
        //[Unique(ErrorMessage = "Ce nom est déjà utilisé")]
        public string Nom
        {
            get { return GetValue(() => Nom); }
            set
            {
                if (Nom != value)
                {
                    SetValue(() => Nom, value);
                }
            }
        }

        [Required(ErrorMessage = "L'indication IsActive est obligatoire")]
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
