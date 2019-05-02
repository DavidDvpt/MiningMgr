namespace BaseClasses
{
    public abstract class BaseController : IController
    {
        public Messenger Messenger => Messenger.Instance;
    }
}
