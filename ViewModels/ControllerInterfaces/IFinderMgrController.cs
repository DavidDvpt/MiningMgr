using BaseClasses;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public interface IFinderMgrController : IController
    {
        FinderListViewData GetFinderListViewData(string filtre);

        ICollection<Finder> GetFinderList(string filtre);

    }
}
