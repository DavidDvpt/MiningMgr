using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Commun")]
    public abstract class Commun
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Nom { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
