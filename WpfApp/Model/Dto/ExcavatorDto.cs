using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Excavator")]
    public class ExcavatorDto : ToolDto
    {
        #region SiPoco
        //public decimal Efficienty { get; set; }
        #endregion

        #region SiDto
        private decimal _efficienty;

        public decimal Efficienty
        {
            get => _efficienty;
            set
            {
                _efficienty = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
    }
}
