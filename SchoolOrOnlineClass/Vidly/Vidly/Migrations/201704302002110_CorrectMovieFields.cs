namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectMovieFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "GenreKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreKey", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
