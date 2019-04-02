using WpfApp.Model;

namespace WpfApp.Repositories.Interfaces
{
    public interface ICommunRepository<T> : IRepository<T>
        where T : CommunModel, new()
    {
        T GetByNom(string nom);
    }
}
