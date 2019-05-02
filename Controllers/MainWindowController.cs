using System;
using Services;
using Services.Interfaces;
using ViewModels;
using Views;

namespace Controllers
{

    /// <summary>
    /// Controller de la fenetre principale
    /// </summary>
    public class MainWindowController : BaseController, IMainWindowController
    {
        private IMainWindowService mainWindowService;

        public MainWindowController(IMainWindowService mws)
        {
            mainWindowService = mws;
        }

        public void Start()
        {
            ShowViewMainWindow();
        }

        #region Affichage vue Principale

        private void ShowViewMainWindow()
        {
            MainWindow v = GetViewMainWindow();
            v.Show();
        }

        private MainWindow GetViewMainWindow()
        {
            MainWindow v = new MainWindow();
            MainWindowViewModel mv = new MainWindowViewModel(this, v);
            return v;
        }

        #endregion

        #region Afficage Elements de fenetre

        public MenuViewModel ShowViewMenu()
        {
            MenuViewModel mv = GetViewMenu(); 
            return mv;
        }



        public StatusViewModel ShowViewStatus()
        {
            StatusViewModel vm = GetViewStatus();

            return vm;
        }

        public FinderMgrViewModel ShowFinderMgrViewModel()
        {
            FinderMgrViewModel vm = GetFinderViewModel();

            return vm;
        }

        private FinderMgrViewModel GetFinderViewModel()
        {
            IFinderMgrController c = new FinderMgrController(new FinderMgrService());
            GeneralMgrView v = new GeneralMgrView();
            FinderMgrViewModel vm = new FinderMgrViewModel(c, v);

            return vm;
        }

        #endregion

        private MenuViewModel GetViewMenu()
        {
            MenuController c = new MenuController(new MenuService());
            MenuView v = new MenuView();

            return new MenuViewModel(c, v);
        }

        private StatusViewModel GetViewStatus()
        {
            StatusController c = new StatusController(new StatusService());
            StatusView v = new StatusView();

            return new StatusViewModel(c, v);
        }
    }
}
