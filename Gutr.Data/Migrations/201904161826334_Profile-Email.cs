namespace Gutr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profile", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profile", "Email");
        }
    }
}
