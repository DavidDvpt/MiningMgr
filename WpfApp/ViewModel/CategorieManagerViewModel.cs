﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    // heritage :
    // BlindableBase : Contient le InotifyChanged et la methode SetProperty
    // BaseViewModel : contient l'instanciation des repositoris repos
    // ManagerViewModel<T> : contient la source generique du datagrid
    public class CategorieManagerViewModel : ManagerViewModel<CategorieModel>
    {
        public CategorieManagerViewModel() : base()
        {

        }
        protected override void Init()
        {
            DataGridItemSource = repos.Categories.GetAll().ToList();
        }
    }
}
