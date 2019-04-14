namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_03 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Refinable",
                c => new
                    {
                        UnrefinedId = c.Int(nullable: false),
                        RefinedId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UnrefinedId, t.RefinedId })
                .ForeignKey("dbo.Material", t => t.UnrefinedId)
                .Index(t => t.UnrefinedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Refinable", "UnrefinedId", "dbo.Material");
            DropIndex("dbo.Refinable", new[] { "UnrefinedId" });
            DropTable("dbo.Refinable");
        }
    }
}
