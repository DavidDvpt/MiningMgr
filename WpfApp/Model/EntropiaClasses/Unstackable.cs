using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Unstackable")]
    public abstract class Unstackable : InWorld
    {
        public Unstackable()
        {
            IsLimited = true;
            Decay = 0;

        }

        [Required]
        public bool IsLimited
        {
            get { return GetValue(() => IsLimited); }
            set
            {
                if (value != IsLimited)
                {
                    SetValue(() => IsLimited, value);
                }
            }
        }

        [Range(0, 9999.999, ErrorMessage = "la valeur doit être entre 0,00001 et 9999,99999")]
        public decimal Decay
        {
            get { return GetValue(() => Decay); }
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
            get { return GetValue(() => Code); }
            set
            {
                if (value != Code)
                {
                    SetValue(() => Code, value.ToUpper());
                }
            }
        }
    }
}
