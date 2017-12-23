namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTicketDashboardEntityNameToTicketCartable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TicketDashboards", newName: "TicketCartables");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TicketCartables", newName: "TicketDashboards");
        }
    }
}
