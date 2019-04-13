using System.Collections.Generic;
using WpfApp.Model.Dto;

namespace WpfApp.Repositories.Interfaces
{
    public interface IModeleRepositoryDto : ICommunRepositoryDto<ModeleDto>
    {
        ICollection<ModeleDto> GetByCategorieName(string nom);
        ICollection<ModeleDto> GetByCategorieId(int id);
    }
}
