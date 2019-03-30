namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Unstackable", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Unstackable", "Code");
        }
    }
}
