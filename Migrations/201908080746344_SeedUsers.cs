namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc2c0593-188d-41c0-8a88-ed5b25484ddf', N'admin@kimji.com', 0, N'ADuYgRPBvOOFFEUrhI81rMAyhqUIwJKy3WVBKGAuJUGfZlG9oVr8pDo85/5Fct3bSA==', N'c2621169-14d0-4174-a929-f4b5795184ed', NULL, 0, 0, NULL, 1, 0, N'admin@kimji.com')");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a0550710-a2e7-4064-a1ba-5c84c487e3b9', N'CanManageMusics')");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dc2c0593-188d-41c0-8a88-ed5b25484ddf', N'a0550710-a2e7-4064-a1ba-5c84c487e3b9')");

        }

        public override void Down()
        {
        }
    }
}
