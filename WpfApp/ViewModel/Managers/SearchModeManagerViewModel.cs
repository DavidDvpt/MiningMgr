using System;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    public class SearchModeManagerViewModel : ManagerViewModel<SearchModeDto>
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
