using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("PlanetMaterial")]
    public class PlanetMaterial
    {
        [Key]
        [Column(Order = 1)]
        public int PlanetId { get; set; }

        [ForeignKey("PlanetId")]
        public PlanetModel Planet { get; set; }

        [Key]
        [Column(Order = 2)]
        public int MaterialId { get; set; }

        [ForeignKey("MaterialId")]
        public MaterialModel Material { get; set; }

    }
}
