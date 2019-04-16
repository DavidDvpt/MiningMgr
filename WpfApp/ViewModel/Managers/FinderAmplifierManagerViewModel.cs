﻿using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class FinderAmplifierManagerViewModel : ManagerViewModel<FinderAmplifier>
    {
        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            DecayVisibility = true;
            CoefficientVisibility = true;
            IsLimitedVisibility = true;
            IsActiveVisibility = true;
            CodeVisibility = true;
        }

        protected override void Init()
        {
            //DataGridItemSource = repos.FinderAmplifiersDto.GetAll().ToList();
        }

    }
}
