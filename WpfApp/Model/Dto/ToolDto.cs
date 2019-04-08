using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Tool")]
    public abstract class ToolDto : UnstackableDto
    {
        #region SiPoco
        //public short UsePerMin { get; set; } = 0;
        #endregion

        #region SiDto
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
        #endregion
    }
}
