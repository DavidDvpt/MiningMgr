using WpfApp.Model;
using System.Data.Entity;

namespace WpfApp.Context

{
    public class MiningContext : DbContext
    {
        //public Context() : base("MiningTest")
        public MiningContext() : base("name=MiningDb")
        {
            //Database.SetInitializer<MiningContext>(new DropCreateDatabaseAlways<MiningContext>());
            //Database.SetInitializer<MiningContext>(new CreateDatabaseIfNotExists<MiningContext>());
            //Database.SetInitializer<MiningContext>(new DropCreateDatabaseIfModelChanges<Context>());
            Database.SetInitializer<MiningContext>(new SeedClass());
        }

        public DbSet<CommunModel> Communs { get; set; }
        public DbSet<InWorldModel> InWorlds { get; set; }
        public DbSet<UnstackableModel> Unstackables { get; set; }
        public DbSet<ToolModel> Tools { get; set; }

        public DbSet<CategorieModel> Categories { get; set; }
        public DbSet<ModeleModel> Modeles { get; set; }
        public DbSet<FinderModel> Finders { get; set; }
        public DbSet<ExcavatorModel> Excavators { get; set; }
        public DbSet<RefinerModel> Refiners { get; set; }
        public DbSet<FinderAmplifierModel> FinderAmplifiers { get; set; }
        public DbSet<EnhancerModel> Enhancers { get; set; }
        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<ToolAccessoireModel> ToolAccessoires { get; set; }
        public DbSet<PlanetMaterialModel> PlanetMaterials { get; set; }
        public DbSet<PlanetModel> Planets { get; set; }

        public DbSet<SearchModeModel> SearchModes { get; set; }
        public DbSet<SetupModel> Setups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Commun
            modelBuilder.Entity<CommunModel>().Property(e => e.Nom).HasColumnType("VARCHAR").HasMaxLength(50);

            // InWorld
            modelBuilder.Entity<InWorldModel>().Property(e => e.Value).HasPrecision(9, 5);

            // Unstackable
            modelBuilder.Entity<UnstackableModel>().Property(e => e.Decay).HasPrecision(7, 3);

            // Tool

            // Finder
            modelBuilder.Entity<FinderModel>().Property(e => e.Depth).HasPrecision(5, 1);
            modelBuilder.Entity<FinderModel>().Property(e => e.Range).HasPrecision(3, 1);

            // Excavator
            modelBuilder.Entity<ExcavatorModel>().Property(e => e.Efficienty).HasPrecision(3, 1);

            // Refiner

            // FinderAmplifier
            modelBuilder.Entity<FinderAmplifierModel>().Property(e => e.Coefficient).HasPrecision(4, 1);

            // Enhancer
            modelBuilder.Entity<EnhancerModel>().Property(e => e.BonusValue1).HasPrecision(3, 1);
            modelBuilder.Entity<EnhancerModel>().Property(e => e.BonusValue2).HasPrecision(3, 1);

        }

    }
}
