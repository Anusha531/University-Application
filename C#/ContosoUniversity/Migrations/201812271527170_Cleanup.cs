namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cleanup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "UserID", "dbo.User");
            DropIndex("dbo.Messages", new[] { "UserID" });
            DropTable("dbo.Messages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        toId = c.Int(nullable: false),
                        msg = c.String(),
                        created_at = c.DateTime(nullable: false),
                        read_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Messages", "UserID");
            AddForeignKey("dbo.Messages", "UserID", "dbo.User", "UserID", cascadeDelete: true);
        }
    }
}
