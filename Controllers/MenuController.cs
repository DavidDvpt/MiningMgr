using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.BaseClasses;

namespace Controllers
{
    class MenuController : BaseController, IMenuController
    {
        public void Start()
        {
            ShowViewMenu();
        }

        private void ShowViewMenu()
        {
            throw new NotImplementedException();
        }
    }
}
