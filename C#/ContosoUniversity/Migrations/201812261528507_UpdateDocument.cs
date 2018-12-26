namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDocument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Document", "DocumentLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Document", "DocumentLink");
        }
    }
}
