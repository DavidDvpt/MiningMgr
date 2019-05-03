using BaseClasses;
using Model;
using Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ViewModels;

namespace Controllers
{
    public class FinderMgrController : BaseController, IFinderMgrController
    {
        private IFinderMgrService _finderMgrService;

        public FinderMgrController(IFinderMgrService fms)
        {
            _finderMgrService = fms;
        }

        public FinderListViewData GetFinderListViewData(string filtre)
        {
            FinderListViewData vd = new FinderListViewData();
            vd.Finders = new ObservableCollection<FinderListItemViewData>();

            foreach (var item in GetFinderList(""))
            {
                vd.Finders.Add(new FinderListItemViewData()
                {
                    Id = item.Id,
                    Nom = item.Nom,
                    Value = item.Value,
                    Decay = item.Decay,
                    IsLimited = item.IsLimited,
                    Depth = item.Depth,
                    Range = item.Range,
                    UsePerMinute = item.UsePerMin,
                    BasePecSearch = item.BasePecSearch
                });
            }

            return vd;
        }

        public ICollection<Finder> GetFinderList(string filtre)
        {
            return _finderMgrService.GetAll().ToList();
        }
    }
}
