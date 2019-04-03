namespace Gutr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Favorite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FavoriteBool = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Note", "IsStarred", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Note", "IsStarred");
            DropTable("dbo.Favorite");
        }
    }
}
