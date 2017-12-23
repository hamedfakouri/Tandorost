namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserUserIdToCustomerIdOnTicket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "User_UserId", "dbo.User");
            DropIndex("dbo.Tickets", new[] { "User_UserId" });
            DropColumn("dbo.Tickets", "CustomerId");
            RenameColumn(table: "dbo.Tickets", name: "User_UserId", newName: "CustomerId");
            AlterColumn("dbo.Tickets", "CustomerId", c => c.Long(nullable: false));
            CreateIndex("dbo.Tickets", "CustomerId");
            AddForeignKey("dbo.Tickets", "CustomerId", "dbo.User", "UserId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "CustomerId", "dbo.User");
            DropIndex("dbo.Tickets", new[] { "CustomerId" });
            AlterColumn("dbo.Tickets", "CustomerId", c => c.Long());
            RenameColumn(table: "dbo.Tickets", name: "CustomerId", newName: "User_UserId");
            AddColumn("dbo.Tickets", "CustomerId", c => c.Long(nullable: false));
            CreateIndex("dbo.Tickets", "User_UserId");
            AddForeignKey("dbo.Tickets", "User_UserId", "dbo.User", "UserId");
        }
    }
}
