﻿using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.ViewModel
{
    public abstract class BaseViewModel : BindableBase
    {
        //protected IRepositoriesUoW repos;
        protected IRepositoriesDtoUoW repos;

        public BaseViewModel()
        {
            if (repos == null)
                //repos = new RepositoriesUoW();
                repos = new RepositoriesDtoUoW();
                

            Init();
        }

        protected abstract void Init();
    }


}
