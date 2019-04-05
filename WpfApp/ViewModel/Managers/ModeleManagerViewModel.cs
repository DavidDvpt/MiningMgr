﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    public class ModeleManagerViewModel : ManagerViewModel<ModeleDto>
    {
        public ModeleManagerViewModel()
        {
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            CategorieNomVisibility = true;
            IsActiveVisibility = true;
        }

        protected override void Init()
        {
            DataGridItemSource = repos.Modeles.GetAll().ToList();
        }
    }
}
