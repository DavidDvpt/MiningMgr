using Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace Services.Context

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

        public DbSet<Commun> Communs { get; set; }
        public DbSet<InWorld> InWorlds { get; set; }
        public DbSet<Unstackable> Unstackables { get; set; }
        public DbSet<Tool> Tools { get; set; }

        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Modele> Modeles { get; set; }
        public DbSet<Finder> Finders { get; set; }
        public DbSet<Excavator> Excavators { get; set; }
        public DbSet<Refiner> Refiners { get; set; }
        public DbSet<FinderAmplifier> FinderAmplifiers { get; set; }
        public DbSet<Enhancer> Enhancers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ToolAccessoire> ToolAccessoires { get; set; }
        public DbSet<PlanetMaterial> PlanetMaterials { get; set; }
        public DbSet<Refinable> Refinables { get; set; }
        public DbSet<Planet> Planets { get; set; }

        public DbSet<SearchMode> SearchModes { get; set; }
        public DbSet<Setup> Setups { get; set; }

        public DbSet<StockMaterial> StockMaterials { get; set; }
        public DbSet<TradeMaterial> TradeMaterials { get; set; }
        public DbSet<TradeState> TradeStates { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(p => p.Name == "Id").Configure(p => p.IsKey());

            // Commun
            modelBuilder.Entity<Commun>().Property(e => e.Nom)
                .IsRequired()
                .HasColumnType("VARCHAR").HasMaxLength(50)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IndexNom") { IsUnique = true }));
            modelBuilder.Entity<Commun>().Property(e => e.IsActive).IsRequired();

            // Modele
            modelBuilder.Entity<Modele>().Property(e => e.IsStackable).IsRequired();
            modelBuilder.Entity<Modele>().Property(e => e.CategorieId).IsRequired();

            // InWorld
            modelBuilder.Entity<InWorld>().Property(e => e.Value).HasPrecision(9, 5);
            modelBuilder.Entity<InWorld>().Property(e => e.ModeleId).IsRequired();

            // Unstackable
            modelBuilder.Entity<Unstackable>().Property(e => e.Decay).HasPrecision(7, 3).IsRequired(); ;
            modelBuilder.Entity<Unstackable>().Property(e => e.IsLimited).IsRequired();
            modelBuilder.Entity<Unstackable>().Property(e => e.Code).HasMaxLength(10);

            // Tool
            modelBuilder.Entity<Tool>().Property(e => e.UsePerMin).IsRequired();

            // Finder
            modelBuilder.Entity<Finder>().Property(e => e.Depth).HasPrecision(5, 1).IsRequired();
            modelBuilder.Entity<Finder>().Property(e => e.Range).HasPrecision(3, 1).IsRequired();
            modelBuilder.Entity<Finder>().Property(e => e.BasePecSearch).IsRequired();

            // Excavator
            modelBuilder.Entity<Excavator>().Property(e => e.Efficienty).HasPrecision(3, 1).IsRequired();

            // Refiner

            // FinderAmplifier
            modelBuilder.Entity<FinderAmplifier>().Property(e => e.Coefficient).HasPrecision(4, 1).IsRequired(); ;

            // Enhancer
            modelBuilder.Entity<Enhancer>().Property(e => e.Slot).IsRequired();
            modelBuilder.Entity<Enhancer>().Property(e => e.BonusValue1).HasPrecision(4, 2).IsRequired(); ;
            modelBuilder.Entity<Enhancer>().Property(e => e.BonusValue2).IsRequired();

            // Refinable
            modelBuilder.Entity<Refinable>().HasKey(p => new { p.UnrefinedMaterial, p.RefinedMaterial });
            modelBuilder.Entity<Refinable>().Property(e => e.Quantity).IsRequired();

            // SearchMode
            modelBuilder.Entity<SearchMode>().Property(e => e.Abbrev).IsRequired().HasMaxLength(3);
            modelBuilder.Entity<SearchMode>().Property(e => e.Multiplicateur).IsRequired();

            // Setup
            modelBuilder.Entity<Setup>().Property(e => e.FinderId).IsRequired();
            modelBuilder.Entity<Setup>().Property(e => e.FinderAmplifierId).IsRequired();
            modelBuilder.Entity<Setup>().Property(e => e.SearchModeId).IsRequired();
            modelBuilder.Entity<Setup>().Property(e => e.DepthEnhancerQty).IsRequired();
            modelBuilder.Entity<Setup>().Property(e => e.RangeEnhancerQty).IsRequired();
            modelBuilder.Entity<Setup>().Property(e => e.SkillEnhancerQty).IsRequired();

            // ToolAccessoire
            modelBuilder.Entity<ToolAccessoire>().HasKey(p => new { p.ToolId, p.AccessoireId });



        }

    }
}
