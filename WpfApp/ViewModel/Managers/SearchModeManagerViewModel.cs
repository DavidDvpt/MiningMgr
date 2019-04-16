using System;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class SearchModeManagerViewModel : ManagerViewModel<SearchMode>
    {
        protected override void ColumnInit()
        {
            NomVisibility = true;
            IsActiveVisibility = true;
            AbbrevVisibility = true;
        }

        protected override void Init()
        {

        }
    }
}
