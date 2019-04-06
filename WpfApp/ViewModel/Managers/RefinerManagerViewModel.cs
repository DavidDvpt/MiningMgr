﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model.Dto;
using WpfApp.Model.Poco;

namespace WpfApp.ViewModel
{
    public class RefinerManagerViewModel : ManagerViewModel<RefinerPoco>
    {
        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            DecayVisibility = true;
            UsePerMinVisibility = true;
            IsLimitedVisibility = true;
            IsActiveVisibility = true;
        }

        protected override void Init()
        {
            DataGridItemSource = repos.RefinersPoco.GetAll().ToList();
        }
    }
}