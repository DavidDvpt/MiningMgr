using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Planet")]
    public class Planet : Commun
    {
        public ICollection<PlanetMaterial> PlanetMaterials { get; set; }
    }
}