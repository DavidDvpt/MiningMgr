﻿using System.Linq;
using WpfApp.Model.Dto;

namespace WpfApp.ViewModel
{
    // heritage :
    // BlindableBase : Contient le InotifyChanged et la methode SetProperty
    // BaseViewModel : contient l'instanciation des repositoris repos
    // ManagerViewModel<T> : contient la source generique du datagrid
    public class CategorieManagerViewModel : ManagerViewModel<CategorieDto>
    {
        //private CommunModel _dgSelectedItem;
        public CategorieManagerViewModel() : base()
        {

        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            IsActiveVisibility = true;
        }

        protected override void Init()
        {
            DataGridItemSource = repos.Categories.GetAll().ToList();         
        }

        //public CommunModel DgSelectedItem
        //{
        //    get => _dgSelectedItem;
        //    set
        //    {
        //        if (_dgSelectedItem != value)
        //        {
        //            _dgSelectedItem = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}


    }
}
