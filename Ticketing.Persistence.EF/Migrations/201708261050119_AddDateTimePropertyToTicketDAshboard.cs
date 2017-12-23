namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimePropertyToTicketDAshboard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketDashboards", "DateTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketDashboards", "DateTime");
        }
    }
}
