namespace SampleApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixedtablename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "IdentityUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.IdentityUsers", newName: "Users");
        }
    }
}
