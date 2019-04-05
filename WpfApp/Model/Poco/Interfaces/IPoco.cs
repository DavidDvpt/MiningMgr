namespace WpfApp.Model.Poco.Interfaces
{
    public interface IPoco<T>
    {
        void SetDto(T entity);

        T GetDto();
    }
}
