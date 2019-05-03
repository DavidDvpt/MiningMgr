using BaseClasses;
using Services.Interfaces;
using System.Windows.Controls;
using ViewModels;
using Views;

namespace Controllers
{
    public class MenuController : BaseController, IMenuController
    {
        private static IMenuService _menuService;
        
        #region Constructeurs

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        #endregion

        public void Start()
        {
            //ShowViewMenu();
        }

        //private void ShowViewMenu()
        //{
        //    MenuView v = GetViewMenu();
        //    v.ShowInWindow(false, "Test",600,400, Dock.Top, null);
        //}

        //private MenuView GetViewMenu()
        //{
        //    MenuView v = new MenuView();
        //    MenuViewModel vm = new MenuViewModel(this, v);

        //    return v;
        //}
    }
}
