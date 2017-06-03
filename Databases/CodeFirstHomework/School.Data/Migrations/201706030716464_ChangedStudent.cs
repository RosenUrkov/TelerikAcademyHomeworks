namespace School.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FirstName", c => c.String());
            AddColumn("dbo.Students", "LastName", c => c.String());
            DropColumn("dbo.Students", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Name", c => c.String());
            DropColumn("dbo.Students", "LastName");
            DropColumn("dbo.Students", "FirstName");
        }
    }
}
