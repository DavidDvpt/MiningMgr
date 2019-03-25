namespace ModelCodeFisrtTPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test02 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Commun", "Nom", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Commun", new[] { "Nom" });
        }
    }
}
