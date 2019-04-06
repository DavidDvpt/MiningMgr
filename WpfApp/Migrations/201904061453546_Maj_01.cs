namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commun",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nom, unique: true);
            
            CreateTable(
                "dbo.PlanetMaterial",
                c => new
                    {
                        PlanetId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlanetId, t.MaterialId })
                .ForeignKey("dbo.Material", t => t.MaterialId)
                .ForeignKey("dbo.Planet", t => t.PlanetId)
                .Index(t => t.PlanetId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.ToolAccessoire",
                c => new
                    {
                        ToolId = c.Int(nullable: false),
                        AccessoireId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ToolId, t.AccessoireId })
                .ForeignKey("dbo.Modele", t => t.AccessoireId)
                .ForeignKey("dbo.Modele", t => t.ToolId)
                .Index(t => t.ToolId)
                .Index(t => t.AccessoireId);
            
            CreateTable(
                "dbo.Categorie",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commun", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.InWorld",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 9, scale: 5),
                        ModeleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commun", t => t.Id)
                .ForeignKey("dbo.Modele", t => t.ModeleId)
                .Index(t => t.Id)
                .Index(t => t.ModeleId);
            
            CreateTable(
                "dbo.Enhancer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Slot = c.Byte(nullable: false),
                        BonusValue1 = c.Decimal(nullable: false, precision: 3, scale: 1),
                        BonusValue2 = c.Decimal(nullable: false, precision: 3, scale: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InWorld", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Unstackable",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsLimited = c.Boolean(nullable: false),
                        Decay = c.Decimal(nullable: false, precision: 7, scale: 3),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InWorld", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tool",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UsePerMin = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Unstackable", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Excavator",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Efficienty = c.Decimal(nullable: false, precision: 3, scale: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tool", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.FinderAmplifier",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Coefficient = c.Decimal(nullable: false, precision: 4, scale: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Unstackable", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Finder",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Depth = c.Decimal(nullable: false, precision: 5, scale: 1),
                        Range = c.Decimal(nullable: false, precision: 3, scale: 1),
                        BasePecSearch = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tool", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InWorld", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Modele",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsStackable = c.Boolean(nullable: false),
                        CategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commun", t => t.Id)
                .ForeignKey("dbo.Categorie", t => t.CategorieId)
                .Index(t => t.Id)
                .Index(t => t.CategorieId);
            
            CreateTable(
                "dbo.Planet",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commun", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Refiner",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tool", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SearchMode",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Abbrev = c.String(),
                        Multiplicateur = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commun", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Setup",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FinderId = c.Int(nullable: false),
                        FinderAmplifierId = c.Int(nullable: false),
                        SearchModeId = c.Int(nullable: false),
                        DeptEnhancerQty = c.Short(nullable: false),
                        RangeEnhancerQty = c.Short(nullable: false),
                        SkillEnhancerQty = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commun", t => t.Id)
                .ForeignKey("dbo.Finder", t => t.FinderId)
                .ForeignKey("dbo.FinderAmplifier", t => t.FinderAmplifierId)
                .ForeignKey("dbo.SearchMode", t => t.SearchModeId)
                .Index(t => t.Id)
                .Index(t => t.FinderId)
                .Index(t => t.FinderAmplifierId)
                .Index(t => t.SearchModeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Setup", "SearchModeId", "dbo.SearchMode");
            DropForeignKey("dbo.Setup", "FinderAmplifierId", "dbo.FinderAmplifier");
            DropForeignKey("dbo.Setup", "FinderId", "dbo.Finder");
            DropForeignKey("dbo.Setup", "Id", "dbo.Commun");
            DropForeignKey("dbo.SearchMode", "Id", "dbo.Commun");
            DropForeignKey("dbo.Refiner", "Id", "dbo.Tool");
            DropForeignKey("dbo.Planet", "Id", "dbo.Commun");
            DropForeignKey("dbo.Modele", "CategorieId", "dbo.Categorie");
            DropForeignKey("dbo.Modele", "Id", "dbo.Commun");
            DropForeignKey("dbo.Material", "Id", "dbo.InWorld");
            DropForeignKey("dbo.Finder", "Id", "dbo.Tool");
            DropForeignKey("dbo.FinderAmplifier", "Id", "dbo.Unstackable");
            DropForeignKey("dbo.Excavator", "Id", "dbo.Tool");
            DropForeignKey("dbo.Tool", "Id", "dbo.Unstackable");
            DropForeignKey("dbo.Unstackable", "Id", "dbo.InWorld");
            DropForeignKey("dbo.Enhancer", "Id", "dbo.InWorld");
            DropForeignKey("dbo.InWorld", "ModeleId", "dbo.Modele");
            DropForeignKey("dbo.InWorld", "Id", "dbo.Commun");
            DropForeignKey("dbo.Categorie", "Id", "dbo.Commun");
            DropForeignKey("dbo.ToolAccessoire", "ToolId", "dbo.Modele");
            DropForeignKey("dbo.ToolAccessoire", "AccessoireId", "dbo.Modele");
            DropForeignKey("dbo.PlanetMaterial", "PlanetId", "dbo.Planet");
            DropForeignKey("dbo.PlanetMaterial", "MaterialId", "dbo.Material");
            DropIndex("dbo.Setup", new[] { "SearchModeId" });
            DropIndex("dbo.Setup", new[] { "FinderAmplifierId" });
            DropIndex("dbo.Setup", new[] { "FinderId" });
            DropIndex("dbo.Setup", new[] { "Id" });
            DropIndex("dbo.SearchMode", new[] { "Id" });
            DropIndex("dbo.Refiner", new[] { "Id" });
            DropIndex("dbo.Planet", new[] { "Id" });
            DropIndex("dbo.Modele", new[] { "CategorieId" });
            DropIndex("dbo.Modele", new[] { "Id" });
            DropIndex("dbo.Material", new[] { "Id" });
            DropIndex("dbo.Finder", new[] { "Id" });
            DropIndex("dbo.FinderAmplifier", new[] { "Id" });
            DropIndex("dbo.Excavator", new[] { "Id" });
            DropIndex("dbo.Tool", new[] { "Id" });
            DropIndex("dbo.Unstackable", new[] { "Id" });
            DropIndex("dbo.Enhancer", new[] { "Id" });
            DropIndex("dbo.InWorld", new[] { "ModeleId" });
            DropIndex("dbo.InWorld", new[] { "Id" });
            DropIndex("dbo.Categorie", new[] { "Id" });
            DropIndex("dbo.ToolAccessoire", new[] { "AccessoireId" });
            DropIndex("dbo.ToolAccessoire", new[] { "ToolId" });
            DropIndex("dbo.PlanetMaterial", new[] { "MaterialId" });
            DropIndex("dbo.PlanetMaterial", new[] { "PlanetId" });
            DropIndex("dbo.Commun", new[] { "Nom" });
            DropTable("dbo.Setup");
            DropTable("dbo.SearchMode");
            DropTable("dbo.Refiner");
            DropTable("dbo.Planet");
            DropTable("dbo.Modele");
            DropTable("dbo.Material");
            DropTable("dbo.Finder");
            DropTable("dbo.FinderAmplifier");
            DropTable("dbo.Excavator");
            DropTable("dbo.Tool");
            DropTable("dbo.Unstackable");
            DropTable("dbo.Enhancer");
            DropTable("dbo.InWorld");
            DropTable("dbo.Categorie");
            DropTable("dbo.ToolAccessoire");
            DropTable("dbo.PlanetMaterial");
            DropTable("dbo.Commun");
        }
    }
}
