using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model.Dto;

namespace WpfApp.Repositories.Interfaces
{
    public interface IMaterialRepositoryDto : ICommunRepositoryDto<MaterialDto>
    {
        ICollection<MaterialDto> GetByModeleName(string nom);
        ICollection<MaterialDto> GetByModeleId(int id);
    }
}
