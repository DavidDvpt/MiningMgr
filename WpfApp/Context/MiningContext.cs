using WpfApp.Model.Dto;
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

        public DbSet<CommunDto> Communs { get; set; }
        public DbSet<InWorldDto> InWorlds { get; set; }
        public DbSet<UnstackableDto> Unstackables { get; set; }
        public DbSet<ToolDto> Tools { get; set; }

        public DbSet<CategorieDto> Categories { get; set; }
        public DbSet<ModeleDto> Modeles { get; set; }
        public DbSet<FinderDto> Finders { get; set; }
        public DbSet<ExcavatorDto> Excavators { get; set; }
        public DbSet<RefinerDto> Refiners { get; set; }
        public DbSet<FinderAmplifierDto> FinderAmplifiers { get; set; }
        public DbSet<EnhancerDto> Enhancers { get; set; }
        public DbSet<MaterialDto> Materials { get; set; }
        public DbSet<ToolAccessoireDto> ToolAccessoires { get; set; }
        public DbSet<PlanetMaterialDto> PlanetMaterials { get; set; }
        public DbSet<PlanetDto> Planets { get; set; }

        public DbSet<SearchModeDto> SearchModes { get; set; }
        public DbSet<SetupDto> Setups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Commun
            modelBuilder.Entity<CommunDto>().Property(e => e.Nom).HasColumnType("VARCHAR").HasMaxLength(50);

            // InWorld
            modelBuilder.Entity<InWorldDto>().Property(e => e.Value).HasPrecision(9, 5);

            // Unstackable
            modelBuilder.Entity<UnstackableDto>().Property(e => e.Decay).HasPrecision(7, 3);

            // Tool

            // Finder
            modelBuilder.Entity<FinderDto>().Property(e => e.Depth).HasPrecision(5, 1);
            modelBuilder.Entity<FinderDto>().Property(e => e.Range).HasPrecision(3, 1);

            // Excavator
            modelBuilder.Entity<ExcavatorDto>().Property(e => e.Efficienty).HasPrecision(3, 1);

            // Refiner

            // FinderAmplifier
            modelBuilder.Entity<FinderAmplifierDto>().Property(e => e.Coefficient).HasPrecision(4, 1);

            // Enhancer
            modelBuilder.Entity<EnhancerDto>().Property(e => e.BonusValue1).HasPrecision(3, 1);
            modelBuilder.Entity<EnhancerDto>().Property(e => e.BonusValue2).HasPrecision(3, 1);

        }

    }
}
