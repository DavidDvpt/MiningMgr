using System.Data.Entity;
using System.IO;

namespace Services.Context
{
    public class SeedClass : CreateDatabaseIfNotExists<MiningContext>
    {
        private MiningContext context;

        protected override void Seed(MiningContext ctx)
        {
            context = ctx;

            SqlScript();
            base.Seed(ctx);
        }

        private void SqlScript()
        {
            string script = File.ReadAllText(@"H:\Data\script.sql");
            context.Database.ExecuteSqlCommand(script);
        }
    }
}

