using ModelCodeFisrtTPT.Repositories;
using ModelCodeFisrtTPT.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT
{
    public class SeedClass : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context ctx)
        {
            IRepositoriesUoW repositories = new RepositoriesUoW(ctx);
            SeedStaticMethods.Seed(repositories);

            base.Seed(ctx);
        }
    }
}
