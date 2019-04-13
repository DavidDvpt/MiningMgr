using System.Collections.Generic;
using System.Linq;
using WpfApp.Context;
using WpfApp.Model.Dto;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.Repositories
{
    public class ModeleRepositoryDto : CommunRepositoryDto<ModeleDto>, IModeleRepositoryDto
    {
        public ModeleRepositoryDto(MiningContext ctx)
            : base(ctx)
        {

        }

        public ICollection<ModeleDto> GetByCategorieId(int id)
        {
            return DbSet.Where(x => x.CategorieDto.Id == id).ToList();
        }

        public ICollection<ModeleDto> GetByCategorieName(string nom)
        {
            return DbSet.Where(x => x.CategorieDto.Nom == nom).ToList();
        }
    }
}
