using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Tool")]
    public abstract class Tool : Unstackable
    {
        public Tool()
        {
            UsePerMin = 0;
        }

        public short UsePerMin
        {
            get { return GetValue(() => UsePerMin); }
            set
            {
                if (value != UsePerMin)
                {
                    SetValue(() => UsePerMin, value);
                }
            }
        }
    }
}
