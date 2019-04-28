using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Unstackable")]
    public abstract class Unstackable : InWorld
    {
        public bool IsLimited { get; set; }

        public decimal Decay { get; set; }

        public string Code { get; set; }
    }
}
