using WpfApp.Model.Dto;
using WpfApp.Model.Dto.Interfaces;
using WpfApp.Model.Poco.Interfaces;

namespace WpfApp.Repositories.Interfaces
{
    public interface ICommunRepository<TDto, TPoco> : IRepository<TDto, TPoco>
        where TDto : class, ICommunDto, new()
        where TPoco : class, IPoco<TDto>, new()
    {
        TPoco GetByNom(string nom);
    }
}
