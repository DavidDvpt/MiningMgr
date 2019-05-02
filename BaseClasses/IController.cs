using Messengers;

namespace BaseClasses
{
    public interface IController
    {
        Messenger Messenger { get; }
    }
}
