namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Enhancer", "BonusValue1", c => c.Decimal(nullable: false, precision: 4, scale: 2));
            AlterColumn("dbo.Enhancer", "BonusValue2", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Enhancer", "BonusValue2", c => c.Decimal(nullable: false, precision: 3, scale: 1));
            AlterColumn("dbo.Enhancer", "BonusValue1", c => c.Decimal(nullable: false, precision: 3, scale: 1));
        }
    }
}
