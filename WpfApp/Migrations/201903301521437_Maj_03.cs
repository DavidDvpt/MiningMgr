namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Setup", "SearchMode_Id", c => c.Int());
            CreateIndex("dbo.Setup", "SearchMode_Id");
            AddForeignKey("dbo.Setup", "SearchMode_Id", "dbo.SearchMode", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Setup", "SearchMode_Id", "dbo.SearchMode");
            DropIndex("dbo.Setup", new[] { "SearchMode_Id" });
            DropColumn("dbo.Setup", "SearchMode_Id");
        }
    }
}
