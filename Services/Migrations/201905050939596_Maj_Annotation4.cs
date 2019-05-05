namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_Annotation4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Commun", new[] { "Nom" });
            AlterColumn("dbo.Commun", "Nom", c => c.String(nullable: false, maxLength: 50, unicode: false));
            CreateIndex("dbo.Commun", "Nom", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Commun", new[] { "Nom" });
            AlterColumn("dbo.Commun", "Nom", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Commun", "Nom", unique: true);
        }
    }
}
