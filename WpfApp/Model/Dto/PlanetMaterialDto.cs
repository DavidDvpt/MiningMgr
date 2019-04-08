using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("PlanetMaterial")]
    public class PlanetMaterialDto : BaseDto
    {
        #region SiPoco
        //[Key]
        //[Column(Order = 1)]
        //public int PlanetId { get; set; }

        //[ForeignKey("PlanetId")]
        //public PlanetDto Planet { get; set; }

        //[Key]
        //[Column(Order = 2)]
        //public int MaterialId { get; set; }

        //[ForeignKey("MaterialId")]
        //public MaterialDto Material { get; set; }
        #endregion

        #region SiDto
        private int _planetId;
        private PlanetDto _planet;
        private int _materialId;
        private MaterialDto _material;

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
        public PlanetDto Planet
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
        public MaterialDto Material
        {
            get => _material;
            set
            {
                _material = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

    }
}
