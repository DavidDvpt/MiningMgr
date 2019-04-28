using Services;

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
            ICategorieService ic = new CategorieServices();

        }

        #region Constructeurs
    }
}
