using Messengers;
using ViewModels;

namespace Controllers
{
    public abstract class BaseController : IController
    {
        //utilisée dans le cas d'une mono fenetre
        //protected static IView MainWindow { get; private set; }

        //public BaseController(IView mainWindow = null)
        //{
        //    MainWindow = mainWindow;
        //}

        public Messenger Messenger => Messenger.Instance;
    }
}
