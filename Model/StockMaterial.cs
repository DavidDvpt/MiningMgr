using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Model
{
    [Table("StockMaterial")]
    public class StockMaterial : Material
    {
        public StockMaterial()
        {
            Quantity = 0;
        }

        public int Quantity { get; set; }

    }
}
