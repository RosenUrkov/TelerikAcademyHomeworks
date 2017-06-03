namespace School.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedConstraints : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Homework", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Materials", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Homework", "Student_Id", "dbo.Students");
            DropIndex("dbo.Homework", new[] { "Course_Id" });
            DropIndex("dbo.Homework", new[] { "Student_Id" });
            DropIndex("dbo.Students", new[] { "City_Id" });
            DropIndex("dbo.Materials", new[] { "Course_Id" });
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Homework", "Content", c => c.String(maxLength: 40));
            AlterColumn("dbo.Homework", "Course_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Homework", "Student_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Students", "City_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Materials", "Course_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Homework", "Course_Id");
            CreateIndex("dbo.Homework", "Student_Id");
            CreateIndex("dbo.Students", "Number", unique: true);
            CreateIndex("dbo.Students", "City_Id");
            CreateIndex("dbo.Materials", "Course_Id");
            AddForeignKey("dbo.Students", "City_Id", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Homework", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Materials", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Homework", "Student_Id", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homework", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Materials", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Homework", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Students", "City_Id", "dbo.Cities");
            DropIndex("dbo.Materials", new[] { "Course_Id" });
            DropIndex("dbo.Students", new[] { "City_Id" });
            DropIndex("dbo.Students", new[] { "Number" });
            DropIndex("dbo.Homework", new[] { "Student_Id" });
            DropIndex("dbo.Homework", new[] { "Course_Id" });
            AlterColumn("dbo.Materials", "Course_Id", c => c.Int());
            AlterColumn("dbo.Students", "City_Id", c => c.Int());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Homework", "Student_Id", c => c.Int());
            AlterColumn("dbo.Homework", "Course_Id", c => c.Int());
            AlterColumn("dbo.Homework", "Content", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            AlterColumn("dbo.Cities", "Name", c => c.String());
            CreateIndex("dbo.Materials", "Course_Id");
            CreateIndex("dbo.Students", "City_Id");
            CreateIndex("dbo.Homework", "Student_Id");
            CreateIndex("dbo.Homework", "Course_Id");
            AddForeignKey("dbo.Homework", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Materials", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.Homework", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.Students", "City_Id", "dbo.Cities", "Id");
        }
    }
}
