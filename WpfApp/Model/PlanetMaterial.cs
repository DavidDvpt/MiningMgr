using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("PlanetMaterial")]
    public class PlanetMaterial : BindableBase
    {
        [Key]
        [Column(Order = 1)]
        public int PlanetId
        {
            get { return GetValue(() => PlanetId); }
            set
            {
                if (value != PlanetId)
                {
                    SetValue(() => PlanetId, value);
                }
            }
        }

        [ForeignKey("PlanetId")]
        public Planet Planet
        {
            get { return GetValue(() => Planet); }
            set
            {
                if (value != Planet)
                {
                    SetValue(() => Planet, value);
                    PlanetId = value.Id;
                }
            }
        }

        [Key]
        [Column(Order = 2)]
        public int MaterialId
        {
            get { return GetValue(() => MaterialId); }
            set
            {
                if (value != MaterialId)
                {
                    SetValue(() => MaterialId, value);
                }
            }
        }

        [ForeignKey("MaterialId")]
        public Material Material
        {
            get { return GetValue(() => Material); }
            set
            {
                if (value != Material)
                {
                    SetValue(() => Material, value);
                    MaterialId = value.Id;
                }
            }
        }

    }
}
