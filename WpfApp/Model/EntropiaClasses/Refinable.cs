using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Refinable")]
    public class Refinable : BindableBase
    {

        [Key]
        [Column(Order = 1)]
        public int UnrefinedId
        {
            get { return GetValue(() => UnrefinedId); }
            set
            {
                if (value != UnrefinedId)
                {
                    SetValue(() => UnrefinedId, value);
                }
            }
        }

        [Key]
        [Column(Order = 2)]
        public int RefinedId
        {
            get { return GetValue(() => RefinedId); }
            set
            {
                if (value != RefinedId)
                {
                    SetValue(() => RefinedId, value);
                }
            }
        }

        [ForeignKey("UnrefinedId")]
        public Material UnrefinedMaterial
        {
            get { return GetValue(() => UnrefinedMaterial); }
            set
            {
                if (value != UnrefinedMaterial)
                {
                    SetValue(() => UnrefinedMaterial, value);
                    UnrefinedId = value.Id;
                }
            }
        }

        [ForeignKey("RefinedId")]
        public Material RefinedMaterial
        {
            get { return GetValue(() => RefinedMaterial); }
            set
            {
                if (value != RefinedMaterial)
                {
                    SetValue(() => RefinedMaterial, value);
                    RefinedId = value.Id;
                }
            }
        }

        public int Quantity
        {
            get { return GetValue(() => Quantity); }
            set
            {
                if (value != Quantity)
                {
                    SetValue(() => Quantity, value);
                }
            }
        }
    }
}
