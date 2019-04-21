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

        [Range(0, 9999.99999, ErrorMessage="la valeur doit être entre 0,00001 et 9999,99999")]
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
        [Required(ErrorMessage = "Le modéle d'item est obligatoire")]
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
