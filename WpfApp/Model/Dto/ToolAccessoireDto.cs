using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("ToolAccessoire")]
    public class ToolAccessoireDto : BaseDto
    {
        #region SiPoco
        //[Key]
        //[Column(Order = 1)]
        //public int ToolId { get; set; }

        //[ForeignKey("ToolId")]
        //public ModeleDto Tool { get; set; }

        //[Key]
        //[Column(Order = 2)]
        //public int AccessoireId { get; set; }

        //[ForeignKey("AccessoireId")]
        //public ModeleDto Accessoire { get; set; }
        #endregion

        #region SiDto
        private int _toolId;
        private ModeleDto _tool;
        private int _accessoireId;
        private ModeleDto _accessoire;

        [Key]
        [Column(Order = 1)]
        public int ToolId
        {
            get => _toolId;
            set
            {
                _toolId = value;
                NotifyPropertyChanged();
            }
        }

        [ForeignKey("ToolId")]
        public ModeleDto Tool
        {
            get => _tool;
            set
            {
                _tool = value;
                NotifyPropertyChanged();
            }
        }

        [Key]
        [Column(Order = 2)]
        public int AccessoireId
        {
            get => _accessoireId;
            set
            {
                _accessoireId = value;
                NotifyPropertyChanged();
            }
        }

        [ForeignKey("AccessoireId")]
        public ModeleDto Accessoire
        {
            get => _accessoire;
            set
            {
                _accessoire = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
    }
}
