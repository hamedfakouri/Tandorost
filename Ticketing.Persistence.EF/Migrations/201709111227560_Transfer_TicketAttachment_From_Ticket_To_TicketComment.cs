namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transfer_TicketAttachment_From_Ticket_To_TicketComment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketAttachments", "TicketId", "dbo.Tickets");
            DropIndex("dbo.TicketAttachments", new[] { "TicketId" });
            AddColumn("dbo.TicketAttachments", "TicketCommentId", c => c.Long(nullable: false));
            CreateIndex("dbo.TicketAttachments", "TicketCommentId");
            AddForeignKey("dbo.TicketAttachments", "TicketCommentId", "dbo.TicketComments", "Id", cascadeDelete: true);
            DropColumn("dbo.TicketAttachments", "TicketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketAttachments", "TicketId", c => c.Long(nullable: false));
            DropForeignKey("dbo.TicketAttachments", "TicketCommentId", "dbo.TicketComments");
            DropIndex("dbo.TicketAttachments", new[] { "TicketCommentId" });
            DropColumn("dbo.TicketAttachments", "TicketCommentId");
            CreateIndex("dbo.TicketAttachments", "TicketId");
            AddForeignKey("dbo.TicketAttachments", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
    }
}
