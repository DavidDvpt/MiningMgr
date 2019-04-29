namespace Services.Interfaces
{
    public interface IInWorldService<T> : ICommunService<T>
        where T : class, new()
    {

    }
}
