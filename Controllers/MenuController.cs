using Services.Interfaces;
using ViewModels;
using ViewModels.BaseClasses;
using Views;

namespace Controllers
{
    public class MenuController : BaseController, IMenuController
    {
        private static IMenuService MenuService;

        #region Constructeurs

        public MenuController(IMenuService menuService)
        {
            MenuService = menuService;
        }

        #endregion

        public void Start()
        {
            ShowViewMenu();
        }

        private void ShowViewMenu()
        {
            MenuView v = GetViewMenu();
        }

        private MenuView GetViewMenu()
        {
            MenuView v = new MenuView();
            MenuViewModel vm = new MenuViewModel(this, v);

            return v;


        }
    }
}
