using WpfApp.Model.Dto;

namespace WpfApp.Repositories.Interfaces
{
    public interface ICommunRepository<T> : IRepository<T>
        where T : CommunDto, new()
    {
        T GetByNom(string nom);
    }
}
