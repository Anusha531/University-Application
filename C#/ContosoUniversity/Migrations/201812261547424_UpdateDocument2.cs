namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDocument2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Document", "Course_CourseID", "dbo.Course");
            DropIndex("dbo.Document", new[] { "Course_CourseID" });
            RenameColumn(table: "dbo.Document", name: "Course_CourseID", newName: "CourseID");
            AlterColumn("dbo.Document", "CourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Document", "CourseID");
            AddForeignKey("dbo.Document", "CourseID", "dbo.Course", "CourseID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Document", "CourseID", "dbo.Course");
            DropIndex("dbo.Document", new[] { "CourseID" });
            AlterColumn("dbo.Document", "CourseID", c => c.Int());
            RenameColumn(table: "dbo.Document", name: "CourseID", newName: "Course_CourseID");
            CreateIndex("dbo.Document", "Course_CourseID");
            AddForeignKey("dbo.Document", "Course_CourseID", "dbo.Course", "CourseID");
        }
    }
}
