using WpfApp.Model.Dto;
using WpfApp.Repositories.Interfaces;
using System.Data.Entity;
using WpfApp.Context;
using System.Linq;

namespace WpfApp.Repositories
{
    public class CommunRepository<T> : Repository<T>, ICommunRepository<T>
        where T : CommunDto, new()
    {
        public CommunRepository(MiningContext ctx)
            : base(ctx)
        {

        }

        public T GetByNom(string nom)
        {
            return DbSet.FirstOrDefault(x => x.Nom == nom);
        }
    }
}
