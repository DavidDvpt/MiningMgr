using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("InWorld")]
    public abstract class InWorld : Commun
    {
        public InWorld()
        {
            Value = 0;
            ModeleId = 0;
        }

        public decimal Value
        {
            get { return GetValue(() => Value); }
            set
            {
                if (value != Value)
                {
                    SetValue(() => Value, value);
                }
            }
        }

        public int ModeleId
        {
            get { return GetValue(() => ModeleId); }
            set
            {
                if (value != ModeleId)
                {
                    SetValue(() => ModeleId, value);
                }
            }
        }

        [ForeignKey("ModeleId")]
        public virtual Modele Modele
        {
            get { return GetValue(() => Modele); }
            set
            {
                if (value != Modele)
                {
                    SetValue(() => Modele, value);
                    ModeleId = value.Id;
                }
            }
        }
    }
}
