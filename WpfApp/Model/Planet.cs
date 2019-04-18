using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Planet")]
    public class Planet : Commun
    {
        public Planet()
        {
            PlanetMaterials = new List<PlanetMaterial>();
        }

        public ICollection<PlanetMaterial> PlanetMaterials { get; set; }
    }
}