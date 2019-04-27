using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Material")]
    public class Material : InWorld
    {
        [InverseProperty("UnrefinedMaterial")]
        public virtual ICollection<Refinable> RefinedTo { get; set; }

        [InverseProperty("RefinedMaterial")]
        public virtual ICollection<Refinable> RefinedFrom { get; set; }
    }
}
