using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("Material")]
    public class Material : InWorld
    {
        [InverseProperty("UnrefinedMaterial")]
        public ICollection<Refinable> RefinedTo { get; set; }

        [InverseProperty("RefinedMaterial")]
        public ICollection<Refinable> RefinedFrom { get; set; }
    }
}
