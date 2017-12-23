namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_LogTicketEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogTickets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TicketId = c.Long(nullable: false),
                        DateTime = c.String(),
                        SenderId = c.Long(nullable: false),
                        ReciverId = c.Long(nullable: false),
                        TicketState = c.Int(nullable: false),
                        User_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .Index(t => t.TicketId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogTickets", "User_UserId", "dbo.User");
            DropForeignKey("dbo.LogTickets", "TicketId", "dbo.Tickets");
            DropIndex("dbo.LogTickets", new[] { "User_UserId" });
            DropIndex("dbo.LogTickets", new[] { "TicketId" });
            DropTable("dbo.LogTickets");
        }
    }
}
