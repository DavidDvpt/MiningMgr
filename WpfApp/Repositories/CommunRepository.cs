using WpfApp.Model.Dto;
using WpfApp.Repositories.Interfaces;
using System.Data.Entity;
using WpfApp.Context;
using System.Linq;
using WpfApp.Tools;
using WpfApp.Model.Dto.Interfaces;
using WpfApp.Model.Poco.Interfaces;

namespace WpfApp.Repositories
{
    public class CommunRepository<TDto, TPoco> : Repository<TDto, TPoco>, ICommunRepository<TDto, TPoco>
        where TDto : class, ICommunDto, new()
        where TPoco : class, IPoco<TDto>, new()
    {
        public CommunRepository(MiningContext ctx)
            : base(ctx)
        {

        }

        public TPoco GetByNom(string nom)
        {
            return DbSet.FirstOrDefault(x => x.Nom == nom).ToPoco<TDto, TPoco>();
        }
    }
}
