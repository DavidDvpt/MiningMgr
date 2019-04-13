﻿using System.Linq;
using WpfApp.Model.Dto;
using WpfApp.Model.Poco;

namespace WpfApp.ViewModel
{
    public class EnhancerManagerViewModel : ManagerViewModel<EnhancerDto>
    {
        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            ModeleNomVisibility = true;
            IsActiveVisibility = true;
            SlotVisibility = true;
            BonusValue1Visibility = true;
            BonusValue2Visibility = true;
        }

        protected override void Init()
        {
        }

    }
}
