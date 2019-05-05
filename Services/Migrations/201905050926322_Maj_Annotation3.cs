namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_Annotation3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categorie", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Enhancer", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Unstackable", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Tool", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Excavator", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.FinderAmplifier", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Finder", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Material", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Planet", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Refiner", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.SearchMode", "Commun_Id", "dbo.Commun");
            DropForeignKey("dbo.Setup", "Commun_Id", "dbo.Commun");
            DropIndex("dbo.Categorie", new[] { "Commun_Id" });
            DropIndex("dbo.InWorld", new[] { "Commun_Id" });
            DropIndex("dbo.InWorld", new[] { "ModeleId" });
            DropIndex("dbo.Enhancer", new[] { "Commun_Id" });
            DropIndex("dbo.Unstackable", new[] { "Commun_Id" });
            DropIndex("dbo.Tool", new[] { "Commun_Id" });
            DropIndex("dbo.Excavator", new[] { "Commun_Id" });
            DropIndex("dbo.FinderAmplifier", new[] { "Commun_Id" });
            DropIndex("dbo.Finder", new[] { "Commun_Id" });
            DropIndex("dbo.Material", new[] { "Commun_Id" });
            DropIndex("dbo.Modele", new[] { "Commun_Id" });
            DropIndex("dbo.Modele", new[] { "CategorieId" });
            DropIndex("dbo.Planet", new[] { "Commun_Id" });
            DropIndex("dbo.Refiner", new[] { "Commun_Id" });
            DropIndex("dbo.SearchMode", new[] { "Commun_Id" });
            DropIndex("dbo.Setup", new[] { "Commun_Id" });
            DropColumn("dbo.InWorld", "ModeleId");
            DropColumn("dbo.Modele", "CategorieId");
            RenameColumn(table: "dbo.Modele", name: "Commun_Id", newName: "CategorieId");
            RenameColumn(table: "dbo.InWorld", name: "Commun_Id", newName: "ModeleId");
            AlterColumn("dbo.InWorld", "ModeleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Modele", "CategorieId", c => c.Int(nullable: false));
            CreateIndex("dbo.InWorld", "ModeleId");
            CreateIndex("dbo.Modele", "CategorieId");
            DropColumn("dbo.Categorie", "Commun_Id");
            DropColumn("dbo.Enhancer", "Commun_Id");
            DropColumn("dbo.Excavator", "Commun_Id");
            DropColumn("dbo.FinderAmplifier", "Commun_Id");
            DropColumn("dbo.Finder", "Commun_Id");
            DropColumn("dbo.Material", "Commun_Id");
            DropColumn("dbo.Planet", "Commun_Id");
            DropColumn("dbo.Refiner", "Commun_Id");
            DropColumn("dbo.SearchMode", "Commun_Id");
            DropColumn("dbo.Setup", "Commun_Id");
            DropColumn("dbo.Tool", "Commun_Id");
            DropColumn("dbo.Unstackable", "Commun_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Unstackable", "Commun_Id", c => c.Int());
            AddColumn("dbo.Tool", "Commun_Id", c => c.Int());
            AddColumn("dbo.Setup", "Commun_Id", c => c.Int());
            AddColumn("dbo.SearchMode", "Commun_Id", c => c.Int());
            AddColumn("dbo.Refiner", "Commun_Id", c => c.Int());
            AddColumn("dbo.Planet", "Commun_Id", c => c.Int());
            AddColumn("dbo.Material", "Commun_Id", c => c.Int());
            AddColumn("dbo.Finder", "Commun_Id", c => c.Int());
            AddColumn("dbo.FinderAmplifier", "Commun_Id", c => c.Int());
            AddColumn("dbo.Excavator", "Commun_Id", c => c.Int());
            AddColumn("dbo.Enhancer", "Commun_Id", c => c.Int());
            AddColumn("dbo.Categorie", "Commun_Id", c => c.Int());
            DropIndex("dbo.Modele", new[] { "CategorieId" });
            DropIndex("dbo.InWorld", new[] { "ModeleId" });
            AlterColumn("dbo.Modele", "CategorieId", c => c.Int());
            AlterColumn("dbo.InWorld", "ModeleId", c => c.Int());
            RenameColumn(table: "dbo.InWorld", name: "ModeleId", newName: "Commun_Id");
            RenameColumn(table: "dbo.Modele", name: "CategorieId", newName: "Commun_Id");
            AddColumn("dbo.Modele", "CategorieId", c => c.Int(nullable: false));
            AddColumn("dbo.InWorld", "ModeleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Setup", "Commun_Id");
            CreateIndex("dbo.SearchMode", "Commun_Id");
            CreateIndex("dbo.Refiner", "Commun_Id");
            CreateIndex("dbo.Planet", "Commun_Id");
            CreateIndex("dbo.Modele", "CategorieId");
            CreateIndex("dbo.Modele", "Commun_Id");
            CreateIndex("dbo.Material", "Commun_Id");
            CreateIndex("dbo.Finder", "Commun_Id");
            CreateIndex("dbo.FinderAmplifier", "Commun_Id");
            CreateIndex("dbo.Excavator", "Commun_Id");
            CreateIndex("dbo.Tool", "Commun_Id");
            CreateIndex("dbo.Unstackable", "Commun_Id");
            CreateIndex("dbo.Enhancer", "Commun_Id");
            CreateIndex("dbo.InWorld", "ModeleId");
            CreateIndex("dbo.InWorld", "Commun_Id");
            CreateIndex("dbo.Categorie", "Commun_Id");
            AddForeignKey("dbo.Setup", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.SearchMode", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Refiner", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Planet", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Material", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Finder", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.FinderAmplifier", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Excavator", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Tool", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Unstackable", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Enhancer", "Commun_Id", "dbo.Commun", "Id");
            AddForeignKey("dbo.Categorie", "Commun_Id", "dbo.Commun", "Id");
        }
    }
}
