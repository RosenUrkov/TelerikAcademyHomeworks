namespace SampleApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedvideos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FilePath = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Videos", new[] { "IsDeleted" });
            DropTable("dbo.Videos");
        }
    }
}
