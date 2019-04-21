using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("FinderAmplifier")]
    public class FinderAmplifier : Unstackable
    {
        public FinderAmplifier()
        {
            Coefficient = 0;
        }

        [Range(0.1, 100, ErrorMessage = "Le coefficient doit être compris entre 0.1 et 100")]
        public decimal Coefficient
        {
            get { return GetValue(() => Coefficient); }
            set
            {
                if (value != Coefficient)
                {
                    SetValue(() => Coefficient, value);
                }
            }
        }
    }
}
