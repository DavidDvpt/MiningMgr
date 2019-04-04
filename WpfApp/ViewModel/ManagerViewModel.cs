using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public abstract class ManagerViewModel<T> : BaseViewModel
        where T : class
    {
        private ICollection<T> _dataGridItemSources;

        public ICollection<T> DataGridItemSource
        {
            get { return _dataGridItemSources; }
            set
            {
                if(_dataGridItemSources != value)
                {
                    _dataGridItemSources = value;
                }
            }
        }



    }
}
