namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2d9a2efc-9037-4572-adde-ff32c4fa565b', N'guest@vidly.com', 0, N'AJOXPcw2PT86elMnKQaDYABlno9T1PT7BoqRN4BWGTk7CcWfSYds9fmQztT4JoEk5w==', N'7ee4d7fa-9448-44fd-8552-70525f8fdc2e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8d41b80c-ebd5-40b0-ac8d-d5eb395d6f86', N'admin1@vidly.com', 0, N'APAOURGrsQnHCIO2If0dkyQHbM3T/TzmEzoAch8ImAAF6FWDBpYFn00MFbPKwxeq8A==', N'bf8a35fb-f892-409a-8bba-b2ae2f996cf5', NULL, 0, 0, NULL, 1, 0, N'admin1@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'27f0ee07-08e7-42a8-be38-dab22dbfc2ed', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8d41b80c-ebd5-40b0-ac8d-d5eb395d6f86', N'27f0ee07-08e7-42a8-be38-dab22dbfc2ed')

");
        }
        
        public override void Down()
        {
        }
    }
}
