using WpfApp.Model.Dto;
using WpfApp.Model.Poco.Interfaces;

namespace WpfApp.Repositories.Interfaces
{
    public interface ICommunRepository<TDto, TPoco> : IRepository<TDto, TPoco>
        where TDto : CommunDto, new()
        where TPoco : class, IPoco<TDto>, new()
    {
        TPoco GetByNom(string nom);
    }
}
