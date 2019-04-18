namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maj_02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SearchMode", "Abbrev", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SearchMode", "Abbrev", c => c.String());
        }
    }
}
