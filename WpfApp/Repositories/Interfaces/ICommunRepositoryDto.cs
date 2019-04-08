using WpfApp.Model.Dto;
using WpfApp.Model.Poco.Interfaces;

namespace WpfApp.Repositories.Interfaces
{
    public interface ICommunRepositoryDto<TDto> : IRepositoryDto<TDto>
        where TDto : CommunDto, new()
    {
        TDto GetByNom(string nom);
    }
}
