using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Excavator")]
    public class Excavator : Tool
    {
        public Excavator()
        {
            Efficienty = 0;
        }

        public decimal Efficienty
        {
            get { return GetValue(() => Efficienty); }
            set
            {
                if (value != Efficienty)
                {
                    SetValue(() => Efficienty, value);
                }
            }
        }
    }
}
