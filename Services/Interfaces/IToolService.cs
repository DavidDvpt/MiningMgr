namespace Services.Interfaces
{
    public interface IToolService<T> : IUnstackableService<T>
        where T : class, new()
    {
    }
}
