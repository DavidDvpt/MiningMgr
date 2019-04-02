namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_04 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Planet", "Id", "dbo.Commun");
            CreateTable(
                "dbo.Planet",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commun", t => t.Id);
            
            DropTable("dbo.Planet");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Planet",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Planet", "Id", "dbo.Commun");
            DropTable("dbo.Planet");
            AddForeignKey("dbo.Planet", "Id", "dbo.Commun", "Id");
        }
    }
}
