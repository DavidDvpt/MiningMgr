using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("PlanetMaterial")]
    public class PlanetMaterial : BaseModel
    {
        private int _planetId;
        private Planet _planet;
        private int _materialId;
        private Material _material;

        [Key]
        [Column(Order = 1)]
        public int PlanetId
        {
            get => _planetId;
            set
            {
                _planetId = value;
                NotifyPropertyChanged();
            }
        }

        [ForeignKey("PlanetId")]
        public Planet Planet
        {
            get => _planet;
            set
            {
                _planet = value;
                NotifyPropertyChanged();
            }
        }

        [Key]
        [Column(Order = 2)]
        public int MaterialId
        {
            get => _materialId;
            set
            {
                _materialId = value;
                NotifyPropertyChanged();
            }
        }

        [ForeignKey("MaterialId")]
        public Material Material
        {
            get => _material;
            set
            {
                _material = value;
                NotifyPropertyChanged();
            }
        }

    }
}
