using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Commun")]
    public abstract class Commun
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Nom { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
