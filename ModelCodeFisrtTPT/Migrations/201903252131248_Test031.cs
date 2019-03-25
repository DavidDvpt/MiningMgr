namespace ModelCodeFisrtTPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test031 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Enhancer", "BonusValue1", c => c.Decimal(nullable: false, precision: 3, scale: 1));
            AlterColumn("dbo.Enhancer", "BonusValue2", c => c.Decimal(nullable: false, precision: 3, scale: 1));
            AlterColumn("dbo.Unstackable", "Decay", c => c.Decimal(nullable: false, precision: 7, scale: 3));
            AlterColumn("dbo.FinderAmplifier", "Coefficient", c => c.Decimal(nullable: false, precision: 4, scale: 1));
            AlterColumn("dbo.Tool", "UsePerMin", c => c.Short(nullable: false));
            AlterColumn("dbo.Excavator", "Efficienty", c => c.Decimal(nullable: false, precision: 3, scale: 1));
            AlterColumn("dbo.Finder", "Depth", c => c.Decimal(nullable: false, precision: 5, scale: 1));
            AlterColumn("dbo.Finder", "Range", c => c.Decimal(nullable: false, precision: 3, scale: 1));
            Sql("ALTER TABLE Setup ADD CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([DepthEnhancerQty] + [RangeEnhancerQty] + [SkillEnhancerQty]) <= 10)");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Finder", "Range", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Finder", "Depth", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Excavator", "Efficienty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tool", "UsePerMin", c => c.Int(nullable: false));
            AlterColumn("dbo.FinderAmplifier", "Coefficient", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Unstackable", "Decay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Enhancer", "BonusValue2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Enhancer", "BonusValue1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
