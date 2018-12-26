namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocument : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        DocumentID = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(),
                        Description = c.String(),
                        DocumentType = c.String(),
                        Comment = c.String(),
                        UploadedUser = c.String(maxLength: 50),
                        UploadedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        Course_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.DocumentID)
                .ForeignKey("dbo.Course", t => t.Course_CourseID)
                .Index(t => t.Course_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Document", "Course_CourseID", "dbo.Course");
            DropIndex("dbo.Document", new[] { "Course_CourseID" });
            DropTable("dbo.Document");
        }
    }
}
