namespace SampleApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsDeletedOnPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "IsDeleted");
        }
    }
}
