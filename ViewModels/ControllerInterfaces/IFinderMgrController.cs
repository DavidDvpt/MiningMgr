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

        /// <summary>
        /// renvoi la fenetre de d'edition avec les données de l'item pour modification
        /// </summary>
        /// <param name="fmv"></param>
        /// <param name="fliv"></param>
        FinderEditViewModel GetFinderEditViewModel(FinderMgrViewModel fmv, BaseViewData fliv);

        /// <summary>
        /// renvoi la fenetre de d'edition avec les champs vide pour creation
        /// </summary>
        /// <param name="fmv">viewModel Parent</param>
        FinderEditViewModel GetFinderEditViewModel(FinderMgrViewModel fmv);

    }
}
