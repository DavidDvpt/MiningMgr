namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Setup", "DepthEnhancerQty", c => c.Short(nullable: false));
            DropColumn("dbo.Setup", "DeptEnhancerQty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Setup", "DeptEnhancerQty", c => c.Short(nullable: false));
            DropColumn("dbo.Setup", "DepthEnhancerQty");
        }
    }
}
