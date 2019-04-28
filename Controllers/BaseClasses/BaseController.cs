using Messengers;
using ViewModels;

namespace Controllers
{
    public abstract class BaseController : IController
    {
        public Messenger Messenger => Messenger.Instance;
    }
}
