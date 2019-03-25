namespace ModelCodeFisrtTPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test03 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Commun", new[] { "Nom" });
            AlterColumn("dbo.InWorld", "Value", c => c.Decimal(nullable: false, precision: 9, scale: 5));
            AlterColumn("dbo.Commun", "Nom", c => c.String(nullable: false, maxLength: 50, unicode: false));
            CreateIndex("dbo.Commun", "Nom", unique: true);
            Sql("ALTER TABLE Setup ADD CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([FinderDepthEnhancerQty] + [FinderRangeEnhancerQty] + [FinderSkillEnhancerQty]) <= 10)");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Commun", new[] { "Nom" });
            AlterColumn("dbo.Commun", "Nom", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.InWorld", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Commun", "Nom", unique: true);
        }
    }
}
