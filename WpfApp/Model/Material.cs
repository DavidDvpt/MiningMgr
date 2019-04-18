using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Material")]
    public class Material : InWorld
    {
        public Material()
        {
            RefinedTo = new List<Refinable>();
            RefinedFrom = new List<Refinable>();
        }

        [InverseProperty("UnrefinedMaterial")]
        public ICollection<Refinable> RefinedTo { get; set; }

        [InverseProperty("RefinedMaterial")]
        public ICollection<Refinable> RefinedFrom { get; set; }
    }
}
