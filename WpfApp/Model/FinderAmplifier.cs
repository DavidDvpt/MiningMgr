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
