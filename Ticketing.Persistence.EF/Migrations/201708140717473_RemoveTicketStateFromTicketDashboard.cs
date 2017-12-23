namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTicketStateFromTicketDashboard : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TicketDashboards", "TicketState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketDashboards", "TicketState", c => c.Int(nullable: false));
        }
    }
}
