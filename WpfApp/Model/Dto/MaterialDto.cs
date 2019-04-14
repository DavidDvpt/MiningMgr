using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model.Dto
{
    [Table("Material")]
    public class MaterialDto : InWorldDto
    {
        [InverseProperty("UnrefinedMaterial")]
        public ICollection<RefinableDto> RefinedTo { get; set; }

        [InverseProperty("RefinedMaterial")]
        public ICollection<RefinableDto> RefinedWith { get; set; }
    }
}
