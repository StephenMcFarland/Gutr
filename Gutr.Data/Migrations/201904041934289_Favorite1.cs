namespace Gutr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Favorite1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Favorite");
            AddColumn("dbo.Favorite", "NoteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Favorite", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Favorite", "Id");
            CreateIndex("dbo.Favorite", "NoteId");
            AddForeignKey("dbo.Favorite", "NoteId", "dbo.Note", "NoteId", cascadeDelete: true);
            DropColumn("dbo.Favorite", "FavoriteBool");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Favorite", "FavoriteBool", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Favorite", "NoteId", "dbo.Note");
            DropIndex("dbo.Favorite", new[] { "NoteId" });
            DropPrimaryKey("dbo.Favorite");
            AlterColumn("dbo.Favorite", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Favorite", "NoteId");
            AddPrimaryKey("dbo.Favorite", "Id");
        }
    }
}
