using Model;

namespace Services.Repositories.Interfaces
{
    public interface ICommunRepository<T> : IRepository<T>
        where T : Commun, new()
    {
        T GetByNom(string nom);
    }
}
