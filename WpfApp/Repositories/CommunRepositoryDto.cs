using WpfApp.Model.Dto;
using WpfApp.Repositories.Interfaces;
using System.Data.Entity;
using WpfApp.Context;
using System.Linq;

namespace WpfApp.Repositories
{
    public class CommunRepositoryDto<TDto> : RepositoryDto<TDto>, ICommunRepositoryDto<TDto>
        where TDto : CommunDto, new()
    {
        public CommunRepositoryDto(MiningContext ctx)
            : base(ctx)
        {

        }

        public TDto GetByNom(string nom)
        {
            return DbSet.FirstOrDefault(x => x.Nom == nom);
        }

        public override IQueryable<TDto> GetAll()
        {
            return DbSet.OrderBy(x => x.Nom);
        }
    }
}
