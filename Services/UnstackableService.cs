using Model;
using Services.Interfaces;

namespace Services
{
    public abstract class UnstackableService<T> : InWorldService<T>, IUnstackableService<T>
        where T : Unstackable, new()
    {
    }
}
