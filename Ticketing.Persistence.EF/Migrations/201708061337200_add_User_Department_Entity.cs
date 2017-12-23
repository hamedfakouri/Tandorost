namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_User_Department_Entity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketAttachments", "Ticket_Id", "dbo.Tickets");
            DropIndex("dbo.TicketAttachments", new[] { "Ticket_Id" });
            RenameColumn(table: "dbo.TicketAttachments", name: "Ticket_Id", newName: "TicketId");
            AlterColumn("dbo.TicketAttachments", "TicketId", c => c.Long(nullable: false));
            CreateIndex("dbo.TicketAttachments", "TicketId");
            AddForeignKey("dbo.TicketAttachments", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketAttachments", "TicketId", "dbo.Tickets");
            DropIndex("dbo.TicketAttachments", new[] { "TicketId" });
            AlterColumn("dbo.TicketAttachments", "TicketId", c => c.Long());
            RenameColumn(table: "dbo.TicketAttachments", name: "TicketId", newName: "Ticket_Id");
            CreateIndex("dbo.TicketAttachments", "Ticket_Id");
            AddForeignKey("dbo.TicketAttachments", "Ticket_Id", "dbo.Tickets", "Id");
        }
    }
}
