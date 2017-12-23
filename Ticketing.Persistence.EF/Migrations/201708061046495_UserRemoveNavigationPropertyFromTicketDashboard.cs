namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRemoveNavigationPropertyFromTicketDashboard : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketDashboards", "Users_UserId", "dbo.User");
            DropIndex("dbo.TicketDashboards", new[] { "Users_UserId" });
            DropColumn("dbo.TicketDashboards", "Users_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketDashboards", "Users_UserId", c => c.Long());
            CreateIndex("dbo.TicketDashboards", "Users_UserId");
            AddForeignKey("dbo.TicketDashboards", "Users_UserId", "dbo.User", "UserId");
        }
    }
}
