using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("ToolAccessoire")]
    public class ToolAccessoire : BindableBase
    {
        public ToolAccessoire()
        {

        }

        [Key]
        [Column(Order = 1)]
        public int ToolId
        {
            get { return GetValue(() => ToolId); }
            set
            {
                if (value != ToolId)
                {
                    SetValue(() => ToolId, value);
                }
            }
        }

        [ForeignKey("ToolId")]
        public Modele Tool
        {
            get { return GetValue(() => Tool); }
            set
            {
                if (value != Tool)
                {
                    SetValue(() => Tool, value);
                    ToolId = value.Id;
                }
            }
        }

        [Key]
        [Column(Order = 2)]
        public int AccessoireId
        {
            get { return GetValue(() => AccessoireId); }
            set
            {
                if (value != AccessoireId)
                {
                    SetValue(() => AccessoireId, value);
                }
            }
        }

        [ForeignKey("AccessoireId")]
        public Modele Accessoire
        {
            get { return GetValue(() => Accessoire); }
            set
            {
                if (value != Accessoire)
                {
                    SetValue(() => Accessoire, value);
                    AccessoireId = value.Id;
                }
            }
        }
    }
}
