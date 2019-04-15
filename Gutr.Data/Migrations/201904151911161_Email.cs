namespace Gutr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Email : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Note", "Email");
        }
    }
}
