using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    [Table("StockMaterial")]
    public class StockMaterial : BindableBase
    {
        public StockMaterial()
        {
            Quantity = 0;
        }
        [Key]
        public int MaterialId
        {
            get { return GetValue(() => MaterialId); }
            set
            {
                if (value != MaterialId)
                {
                    SetValue(() => MaterialId, value);
                }
            }
        }

        [ForeignKey("MaterialId")]
        public Material Material
        {
            get { return GetValue(() => Material); }
            set
            {
                if (value != Material)
                {
                    SetValue(() => Material, value);
                }
            }
        }

        [Range(0, int.MaxValue, ErrorMessage = "Le stock ne peut pas être négatif")]
        public int Quantity
        {
            get { return GetValue(() => Quantity); }
            set
            {
                if (value != Quantity)
                {
                    SetValue(() => Quantity, value);
                }
            }
        }

    }
}
