using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Tool")]
    public abstract class Tool : Unstackable
    {
        private short _usePerMin;

        public short UsePerMin
        {
            get => _usePerMin;
            set
            {
                _usePerMin = value;
                NotifyPropertyChanged();
            }
        }
    }
}
