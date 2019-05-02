using Model;
using Services.Interfaces;

namespace Services
{
    public abstract class InWorldService<T> : CommunService<T>, IInWorldService<T>
        where T : InWorld, new()
    {
    }
}
