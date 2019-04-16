using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Planet")]
    public class Planet : Commun
    {
        [InverseProperty("UnrefinedMaterial")]
        public ICollection<PlanetMaterial> PlanetMaterials { get; set; }
    }
}