using BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class FinderEditViewData : BaseViewData
    {
        public int Id
        {
            get => GetValue(() => Id);
            set
            {
                if (value != Id)
                {
                    SetValue(() => Id, value);
                }
            }
        }

        [Required(ErrorMessage = "Le Nom est requis")]
        [MaxLength(50, ErrorMessage = "La longueur maximum est de 50")]
        [Unique(ErrorMessage = "Ce nom est déjà utilisé")]
        public string Nom
        {
            get => GetValue(() => Nom);
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
            get => GetValue(() => IsActive);
            set
            {
                if (value != IsActive)
                {
                    SetValue(() => IsActive, value);
                }
            }
        }

        [Range(0, 9999.99999, ErrorMessage = "la valeur doit être entre 0,00001 et 9999,99999")]
        [Required(ErrorMessage = "La valeur ne peut pas être nulle. mettre 0 si inconnue")]
        public decimal Value
        {
            get => GetValue(() => Value);
            set
            {
                if (value != Value)
                {
                    SetValue(() => Value, value);
                }
            }
        }

        [Required(ErrorMessage = "L'indication IsLimited est obligatoire")]
        public bool IsLimited
        {
            get => GetValue(() => IsLimited);
            set
            {
                if (value != IsLimited)
                {
                    SetValue(() => IsLimited, value);
                }
            }
        }

        [Range(0, 9999.999, ErrorMessage = "la valeur doit être entre 0,00001 et 9999,99999")]
        [Required(ErrorMessage = "La valeur ne peut pas être nulle. mettre 0 si inconnue")]
        public decimal Decay
        {
            get => GetValue(() => Decay);
            set
            {
                if (value != Decay)
                {
                    SetValue(() => Decay, value);
                }
            }
        }

        public string Code
        {
            get => GetValue(() => Code);
            set
            {
                if (value != Code)
                {
                    SetValue(() => Code, value.ToUpper());
                }
            }
        }

        [Required(ErrorMessage = "La valeur ne peut pas être nulle. mettre 0 si inconnue")]
        public short UsePerMin
        {
            get => GetValue(() => UsePerMin);
            set
            {
                if (value != UsePerMin)
                {
                    SetValue(() => UsePerMin, value);
                }
            }
        }

        [Required(ErrorMessage = "La valeur ne peut pas être nulle. mettre 0 si inconnue")]
        [Range(0, 1000, ErrorMessage = "La profondeur doit être comprise entre 0 et 1000")]
        public decimal Depth
        {
            get => GetValue(() => Depth);
            set
            {
                if (value != Depth)
                {
                    SetValue(() => Depth, value);
                }
            }
        }

        [Required(ErrorMessage = "La valeur ne peut pas être nulle. mettre 0 si inconnue")]
        [Range(0, 60, ErrorMessage = "La profondeur doit être comprise entre 0 et 1000")]
        public decimal Range
        {
            get => GetValue(() => Range);
            set
            {
                if (value != Range)
                {
                    SetValue(() => Range, value);
                }
            }
        }

        [Required(ErrorMessage = "La valeur ne peut pas être nulle. mettre 0 si inconnue")]
        public short BasePecSearch
        {
            get => GetValue(() => BasePecSearch);
            set
            {
                if (value != BasePecSearch)
                {
                    SetValue(() => BasePecSearch, value);
                }
            }
        }
    }
}
