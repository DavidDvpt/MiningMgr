
namespace Services.Interfaces
{
    public interface IUnstackableService<T> : IInWorldService<T>
        where T : class, new()
    {
    }
}
