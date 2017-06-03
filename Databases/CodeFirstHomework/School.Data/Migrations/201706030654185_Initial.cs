namespace School.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCourse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.ParentCourse_Id)
                .Index(t => t.ParentCourse_Id);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        TimeSent = c.DateTime(nullable: false),
                        Course_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.Int(nullable: false),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materials", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Homework", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Homework", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "ParentCourse_Id", "dbo.Courses");
            DropIndex("dbo.StudentCourses", new[] { "Course_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Student_Id" });
            DropIndex("dbo.Materials", new[] { "Course_Id" });
            DropIndex("dbo.Homework", new[] { "Student_Id" });
            DropIndex("dbo.Homework", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "ParentCourse_Id" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Materials");
            DropTable("dbo.Students");
            DropTable("dbo.Homework");
            DropTable("dbo.Courses");
        }
    }
}
