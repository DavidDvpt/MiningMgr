namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_Annotation : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Commun", "IndexNom");
            DropIndex("dbo.Setup", new[] { "FinderAmplifierId" });
            AlterColumn("dbo.Commun", "Nom", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Setup", "FinderAmplifierId", c => c.Int());
            CreateIndex("dbo.Commun", "Nom", unique: true);
            CreateIndex("dbo.Setup", "FinderAmplifierId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Setup", new[] { "FinderAmplifierId" });
            DropIndex("dbo.Commun", new[] { "Nom" });
            AlterColumn("dbo.Setup", "FinderAmplifierId", c => c.Int(nullable: false));
            AlterColumn("dbo.Commun", "Nom", c => c.String(nullable: false, maxLength: 50, unicode: false));
            CreateIndex("dbo.Setup", "FinderAmplifierId");
            CreateIndex("dbo.Commun", "Nom", unique: true, name: "IndexNom");
        }
    }
}
