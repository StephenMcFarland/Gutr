namespace Gutr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profile", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profile", "ImageUrl");
        }
    }
}
