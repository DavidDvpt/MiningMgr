namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_Annotation2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Modele", "CategorieId", "dbo.Categorie");
            DropForeignKey("dbo.InWorld", "ModeleId", "dbo.Modele");
            AddColumn("dbo.Categorie", "Commun_Id", c => c.Int());
            AddColumn("dbo.Modele", "Commun_Id", c => c.Int());
            AddColumn("dbo.InWorld", "Commun_Id", c => c.Int());
            AddColumn("dbo.Enhancer", "Commun_Id", c => c.Int());
            AddColumn("dbo.Material", "Commun_Id", c => c.Int());
            AddColumn("dbo.Unstackable", "Commun_Id", c => c.Int());
            AddColumn("dbo.FinderAmplifier", "Commun_Id", c => c.Int());
            AddColumn("dbo.Tool", "Commun_Id", c => c.Int());
            AddColumn("dbo.Excavator", "Commun_Id", c => c.Int());
            AddColumn("dbo.Finder", "Commun_Id", c => c.Int());
            AddColumn("dbo.Refiner", "Commun_Id", c => c.Int());
            AddColumn("dbo.Planet", "Commun_Id", c => c.Int());
            AddColumn("dbo.SearchMode", "Commun_Id", c => c.Int());
            AddColumn("dbo.Setup", "Commun_Id", c => c.Int());
            CreateIndex("dbo.Categorie", "Commun_Id");
            CreateIndex("dbo.InWorld", "Commun_Id");
            CreateIndex("dbo.Enhancer", "Commun_Id");
            CreateIndex("dbo.Unstackable", "Commun_Id");
            CreateIndex("dbo.Tool", "Commun_Id");
            CreateIndex("dbo.Excavator", "Commun_Id");
            CreateIndex("dbo.FinderAmplifier", "Commun_Id");
            CreateIndex("dbo.Finder", "Commun_Id");
            CreateIndex("dbo.Material", "Commun_Id");
            CreateIndex("dbo.Modele", "Commun_Id");
            CreateIndex("dbo.Planet", "Commun_Id");
            CreateIndex("dbo.Refiner", "Commun_Id");
            CreateIndex("dbo.SearchMode", "Commun_Id");
            CreateIndex("dbo.Setup", "Commun_Id");
            AddForeignKey("dbo.Categorie", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Enhancer", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Unstackable", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Tool", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Excavator", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.FinderAmplifier", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Finder", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Material", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Planet", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Refiner", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.SearchMode", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Setup", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Modele", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.InWorld", "Commun_Id", "dbo.Commun", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InWorld", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Modele", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Setup", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.SearchMode", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Refiner", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Planet", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Material", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Finder", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.FinderAmplifier", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Excavator", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Tool", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Unstackable", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Enhancer", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Categorie", "Commun_Id", "dbo.Commun");
            DropIndex("dbo.Setup", new[] { "Commun_Id" });
            DropIndex("dbo.SearchMode", new[] { "Commun_Id" });
            DropIndex("dbo.Refiner", new[] { "Commun_Id" });
            DropIndex("dbo.Planet", new[] { "Commun_Id" });
            DropIndex("dbo.Modele", new[] { "Commun_Id" });
            DropIndex("dbo.Material", new[] { "Commun_Id" });
            DropIndex("dbo.Finder", new[] { "Commun_Id" });
            DropIndex("dbo.FinderAmplifier", new[] { "Commun_Id" });
            DropIndex("dbo.Excavator", new[] { "Commun_Id" });
            DropIndex("dbo.Tool", new[] { "Commun_Id" });
            DropIndex("dbo.Unstackable", new[] { "Commun_Id" });
            DropIndex("dbo.Enhancer", new[] { "Commun_Id" });
            DropIndex("dbo.InWorld", new[] { "Commun_Id" });
            DropIndex("dbo.Categorie", new[] { "Commun_Id" });
            DropColumn("dbo.Setup", "Commun_Id");
            DropColumn("dbo.SearchMode", "Commun_Id");
            DropColumn("dbo.Planet", "Commun_Id");
            DropColumn("dbo.Refiner", "Commun_Id");
            DropColumn("dbo.Finder", "Commun_Id");
            DropColumn("dbo.Excavator", "Commun_Id");
            DropColumn("dbo.Tool", "Commun_Id");
            DropColumn("dbo.FinderAmplifier", "Commun_Id");
            DropColumn("dbo.Unstackable", "Commun_Id");
            DropColumn("dbo.Material", "Commun_Id");
            DropColumn("dbo.Enhancer", "Commun_Id");
            DropColumn("dbo.InWorld", "Commun_Id");
            DropColumn("dbo.Modele", "Commun_Id");
            DropColumn("dbo.Categorie", "Commun_Id");
            AddForeignKey("dbo.InWorld", "ModeleId", "dbo.Modele", "Id");
            AddForeignKey("dbo.Modele", "CategorieId", "dbo.Categorie", "Id");
        }
    }
}
