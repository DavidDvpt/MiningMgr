using System.ComponentModel.DataAnnotations;
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

        [Range(0.1, 99.9, ErrorMessage = "L'efficacité doit être compris entre 0.1 et 99.9")]
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
