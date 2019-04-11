namespace Gutr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Favorite : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favorite", "NoteId", "dbo.Note");
            DropIndex("dbo.Favorite", new[] { "NoteId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Favorite", "NoteId");
            AddForeignKey("dbo.Favorite", "NoteId", "dbo.Note", "NoteId", cascadeDelete: true);
        }
    }
}
