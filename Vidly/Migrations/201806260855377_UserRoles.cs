namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UserRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@" INSERT INTO[dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'e73c3b53-6fe7-48c6-91c2-2124ae7fcc58', N'CanManageMovies')
                   INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9c38e749-b073-46e3-a484-104ebd2933a3', N'manager@vidly.com', 0, N'AKD9dRbdo1yD1K7K6wEO6FKJiHInNCBN1t+1r7I4P74RuZM95echbk0M1BDOqen5tA==', N'c476dc2a-0e6a-4eb1-9441-95d133c578ef', NULL, 0, 0, NULL, 1, 0, N'manager@vidly.com')
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'f99e931d-d283-4acc-889f-d21bc834b8ab', N'user@vidly.com', 0, N'AMQENgX6084q9owUCzI5XcEtDyiyzNK80ha+ym2D7fgv7a0MukWeHT6z/cgFG2dB5Q==', N'f8f2150d-ad1b-4fe2-bf0e-df9b3d83f8bd', NULL, 0, 0, NULL, 1, 0, N'user@vidly.com')
                INSERT INTO dbo.AspNetUserRoles( UserId, RoleId )VALUES  ( N'9c38e749-b073-46e3-a484-104ebd2933a3', N'e73c3b53-6fe7-48c6-91c2-2124ae7fcc58')");
        }

        public override void Down()
        {
        }
    }
}
