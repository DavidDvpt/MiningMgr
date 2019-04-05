using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using WpfApp.Model.Dto.Interfaces;

namespace WpfApp.Model.Dto
{
    [Table("Commun")]
    public abstract class CommunDto : ICommunDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, ErrorMessage = "La longueur maximum est de 50")]
        [Index(IsUnique = true)]
        public string Nom { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
