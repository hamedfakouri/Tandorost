namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEmployeeModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TicketCunstomerComments", newName: "TicketComments");
            DropForeignKey("dbo.TicketEmployeeComments", "TicketCunstomerCommentId", "dbo.TicketCunstomerComments");
            DropIndex("dbo.TicketEmployeeComments", new[] { "TicketCunstomerCommentId" });
            AddColumn("dbo.TicketComments", "UserId", c => c.Long(nullable: false));
            CreateIndex("dbo.TicketComments", "UserId");
            AddForeignKey("dbo.TicketComments", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            DropTable("dbo.TicketEmployeeComments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TicketEmployeeComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Comment = c.String(),
                        DateTime = c.String(),
                        TicketCunstomerCommentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.TicketComments", "UserId", "dbo.User");
            DropIndex("dbo.TicketComments", new[] { "UserId" });
            DropColumn("dbo.TicketComments", "UserId");
            CreateIndex("dbo.TicketEmployeeComments", "TicketCunstomerCommentId");
            AddForeignKey("dbo.TicketEmployeeComments", "TicketCunstomerCommentId", "dbo.TicketCunstomerComments", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.TicketComments", newName: "TicketCunstomerComments");
        }
    }
}
