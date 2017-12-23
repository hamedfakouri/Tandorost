namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Chanage_UserIdFk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "User_UserId", c => c.Long());
            CreateIndex("dbo.Tickets", "User_UserId");
            AddForeignKey("dbo.Tickets", "User_UserId", "dbo.User", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "User_UserId", "dbo.User");
            DropIndex("dbo.Tickets", new[] { "User_UserId" });
            DropColumn("dbo.Tickets", "User_UserId");
        }
    }
}
