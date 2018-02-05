namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPhoneNumberLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UserPhoneNumber", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UserPhoneNumber", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
