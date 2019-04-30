using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel(IController controller)
            : base(controller)
        {
        }

        public MenuViewModel(IController controller, IView view)
            : base(controller, view)
        {
        }
    }
}
