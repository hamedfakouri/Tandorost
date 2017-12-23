namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertPropSenderIdAndReciverIdToUserIdAndChangeAuditLogProp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LogTickets", "User_UserId", "dbo.User");
            DropIndex("dbo.LogTickets", new[] { "User_UserId" });
            RenameColumn(table: "dbo.LogTickets", name: "User_UserId", newName: "UserId");
            AddColumn("dbo.LogTickets", "AuditAction", c => c.Int(nullable: false));
            AlterColumn("dbo.LogTickets", "UserId", c => c.Long(nullable: false));
            CreateIndex("dbo.LogTickets", "UserId");
            AddForeignKey("dbo.LogTickets", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            DropColumn("dbo.LogTickets", "SenderId");
            DropColumn("dbo.LogTickets", "ReciverId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LogTickets", "ReciverId", c => c.Long(nullable: false));
            AddColumn("dbo.LogTickets", "SenderId", c => c.Long(nullable: false));
            DropForeignKey("dbo.LogTickets", "UserId", "dbo.User");
            DropIndex("dbo.LogTickets", new[] { "UserId" });
            AlterColumn("dbo.LogTickets", "UserId", c => c.Long());
            DropColumn("dbo.LogTickets", "AuditAction");
            RenameColumn(table: "dbo.LogTickets", name: "UserId", newName: "User_UserId");
            CreateIndex("dbo.LogTickets", "User_UserId");
            AddForeignKey("dbo.LogTickets", "User_UserId", "dbo.User", "UserId");
        }
    }
}
