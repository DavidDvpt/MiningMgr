using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("PlanetMaterial")]
    public class PlanetMaterialDto
    {
        [Key]
        [Column(Order = 1)]
        public int PlanetId { get; set; }

        [ForeignKey("PlanetId")]
        public PlanetDto Planet { get; set; }

        [Key]
        [Column(Order = 2)]
        public int MaterialId { get; set; }

        [ForeignKey("MaterialId")]
        public MaterialDto Material { get; set; }

    }
}
