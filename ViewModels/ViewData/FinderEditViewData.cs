using BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class FinderEditViewData : UnstackableEditViewData
    {
        

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
