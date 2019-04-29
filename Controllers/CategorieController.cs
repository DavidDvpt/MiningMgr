using Services;
using Services.Interfaces;

namespace Controllers
{
    public class CategorieController : BaseController
    {
        public static ICategorieService CustomerService;

        #region Constructeurs

        public CategorieController()
        {

        }

        public CategorieController(ICategorieService categorService)
        {
            ICategorieService ic = new CategorieService();

        }

        #endregion
    }
}
