namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using WpfApp.Repositories;
    using WpfApp.Repositories.Interfaces;

    internal sealed class Configuration : DbMigrationsConfiguration<WpfApp.Context.MiningContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WpfApp.Context.MiningContext context)
        {
            IRepositoriesUoW repositories = new RepositoriesUoW();
            string script = File.ReadAllText(@"H:\Data\script.sql");
            repositories.GetContext().Database.ExecuteSqlCommand(script);
        }
    }
}
