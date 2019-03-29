using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;
using System.Data.Entity;

namespace WpfApp.Context
{
    public class SeedClass : DropCreateDatabaseAlways<MiningContext>
    {
        protected override void Seed(MiningContext ctx)
        {
            IRepositoriesUoW repositories = new RepositoriesUoW(ctx);
            SeedStaticMethods.Seed(repositories);

            base.Seed(ctx);
        }
    }
}
