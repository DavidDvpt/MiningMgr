using BaseClasses;
using Model;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ViewModels;
using Views;

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
            FinderListItemViewData fliv;
            foreach (var item in GetFinderList(""))
            {
                fliv = new FinderListItemViewData();
                fliv.GetPropertiesValues(item);
                vd.Finders.Add(fliv);
            }

            return vd;
        }

        public ICollection<Finder> GetFinderList(string filtre)
        {
            return _finderMgrService.GetAll().ToList();
        }

        public FinderEditViewModel GetFinderEditViewModel(FinderMgrViewModel fmv, BaseViewData flvd)
        {
            FinderEditViewModel vm = new FinderEditViewModel(this, new FinderEditView());
            FinderEditViewData fevd = GetFinderEditViewData(((FinderListItemViewData)flvd).Id);
            vm.ViewData = fevd;

            return vm;
        }

        private FinderEditViewData GetFinderEditViewData(int id)
        {
            FinderEditViewData fevd = new FinderEditViewData();
            fevd.GetPropertiesValues(_finderMgrService.GetById(id));

            return fevd;
        }

        public FinderEditViewModel GetFinderEditViewModel(FinderMgrViewModel fmv)
        {
            throw new System.NotImplementedException();
        }


    }
}
