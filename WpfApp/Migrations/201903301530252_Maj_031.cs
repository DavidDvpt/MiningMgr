namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_031 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Setup", new[] { "SearchMode_Id" });
            RenameColumn(table: "dbo.Setup", name: "SearchMode_Id", newName: "SearchModeId");
            AlterColumn("dbo.Setup", "SearchModeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Setup", "SearchModeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Setup", new[] { "SearchModeId" });
            AlterColumn("dbo.Setup", "SearchModeId", c => c.Int());
            RenameColumn(table: "dbo.Setup", name: "SearchModeId", newName: "SearchMode_Id");
            CreateIndex("dbo.Setup", "SearchMode_Id");
        }
    }
}
