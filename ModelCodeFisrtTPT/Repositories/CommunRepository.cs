using ModelCodeFisrtTPT.Dto;
using ModelCodeFisrtTPT.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ModelCodeFisrtTPT.Repositories
{
    public class CommunRepository<T> : Repository<T>, ICommunRepository<T>
        where T : Commun, new()
    {
        public CommunRepository(Context ctx)
            : base(ctx)
        {

        }

        public T GetByNom(string nom)
        {
            return DbSet.FirstOrDefault(x => x.Nom == nom);
        }
    }
}
