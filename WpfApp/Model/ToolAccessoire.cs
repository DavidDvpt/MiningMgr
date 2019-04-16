using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("ToolAccessoire")]
    public class ToolAccessoire : BaseModel
    {
        private int _toolId;
        private Modele _tool;
        private int _accessoireId;
        private Modele _accessoire;

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
        public Modele Tool
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
        public Modele Accessoire
        {
            get => _accessoire;
            set
            {
                _accessoire = value;
                NotifyPropertyChanged();
            }
        }
    }
}
