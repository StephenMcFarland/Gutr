namespace Gutr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Summary = c.String(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profile");
        }
    }
}
