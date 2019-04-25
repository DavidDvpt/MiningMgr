using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.ViewModel.UserControlViewModels
{
    public class FormulaireAchatViewModel : BindableBase
    {
        public FormulaireAchatViewModel(StockMaterial stockMaterial)
        {
            Material = stockMaterial;
            Quantity = stockMaterial.Quantity;
        }

        public Material Material { get; set; }

        public int Quantity { get; set; }

    }
}
