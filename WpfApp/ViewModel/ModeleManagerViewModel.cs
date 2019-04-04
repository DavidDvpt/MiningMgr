using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class ModeleManagerViewModel : ManagerViewModel<ModeleModel>
    {
        protected override void Init()
        {
            DataGridItemSource = repos.Modeles.GetAll().ToList();
        }
    }
}
