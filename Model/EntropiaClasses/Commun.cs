using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Commun")]
    public abstract class Commun
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public bool IsActive { get; set; }
    }
}
