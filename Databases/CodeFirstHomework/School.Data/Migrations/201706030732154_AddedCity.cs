namespace School.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "City_Id", c => c.Int());
            AddColumn("dbo.Students", "City_Id", c => c.Int());
            CreateIndex("dbo.Courses", "City_Id");
            CreateIndex("dbo.Students", "City_Id");
            AddForeignKey("dbo.Courses", "City_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.Students", "City_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Courses", "City_Id", "dbo.Cities");
            DropIndex("dbo.Students", new[] { "City_Id" });
            DropIndex("dbo.Courses", new[] { "City_Id" });
            DropColumn("dbo.Students", "City_Id");
            DropColumn("dbo.Courses", "City_Id");
            DropTable("dbo.Cities");
        }
    }
}
