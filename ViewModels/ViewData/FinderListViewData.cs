using BaseClasses;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class FinderListViewData : BaseViewData
    {
        public ObservableCollection<FinderListItemViewData> Finders
        {
            get { return GetValue(() => Finders); }
            set { SetValue(() => Finders, value); }
        }
    }
}
