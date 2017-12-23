namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiallDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProcessSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        ProcessSettingValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketCunstomerComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Comment = c.String(),
                        DateTime = c.String(),
                        TicketId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                        DepartmentId = c.Long(nullable: false),
                        TicketState = c.Int(nullable: false),
                        TicketPriority = c.Int(nullable: false),
                        DateTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.TicketAttachments",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    SrcFile = c.String(),
                    TicketDescription = c.String(),
                    Ticket_Id = c.Long(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_Id)
                .Index(t => t.Ticket_Id);

            CreateTable(
                "dbo.TicketEmployeeComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Comment = c.String(),
                        DateTime = c.String(),
                        TicketCunstomerCommentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketCunstomerComments", t => t.TicketCunstomerCommentId, cascadeDelete: true)
                .Index(t => t.TicketCunstomerCommentId);
            
            CreateTable(
                "dbo.TicketDashboards",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        TicketId = c.Long(nullable: false),
                        SenderId = c.Long(nullable: false),
                        ReciverId = c.Long(nullable: false),
                        TicketState = c.Int(nullable: false),
                        TicketAssigned = c.Boolean(nullable: false),
                        Users_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.Users_UserId)
                .Index(t => t.TicketId)
                .Index(t => t.Users_UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        FirstName = c.String(maxLength: 150),
                        LastName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DepartmentUsers",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        DepartmentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.DepartmentId })
                .ForeignKey("dbo.Department", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.DepartmentId);

            SqlResource(@"Ticketing.Persistence.EF.Resources.InsertDepartmentName.sql");
            SqlResource(@"Ticketing.Persistence.EF.Resources.InsertProcessSetting.sql");


        }

        public override void Down()
        {
            DropForeignKey("dbo.TicketDashboards", "Users_UserId", "dbo.User");
            DropForeignKey("dbo.DepartmentUsers", "DepartmentId", "dbo.User");
            DropForeignKey("dbo.DepartmentUsers", "UserId", "dbo.Department");
            DropForeignKey("dbo.TicketDashboards", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketEmployeeComments", "TicketCunstomerCommentId", "dbo.TicketCunstomerComments");
            DropForeignKey("dbo.TicketCunstomerComments", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketAttachments", "Ticket_Id", "dbo.Tickets");
            DropIndex("dbo.DepartmentUsers", new[] { "DepartmentId" });
            DropIndex("dbo.DepartmentUsers", new[] { "UserId" });
            DropIndex("dbo.TicketDashboards", new[] { "Users_UserId" });
            DropIndex("dbo.TicketDashboards", new[] { "TicketId" });
            DropIndex("dbo.TicketEmployeeComments", new[] { "TicketCunstomerCommentId" });
            DropIndex("dbo.TicketAttachments", new[] { "Ticket_Id" });
            DropIndex("dbo.TicketCunstomerComments", new[] { "TicketId" });
            DropTable("dbo.DepartmentUsers");
            DropTable("dbo.Department");
            DropTable("dbo.User");
            DropTable("dbo.TicketDashboards");
            DropTable("dbo.TicketEmployeeComments");
            DropTable("dbo.TicketAttachments");
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketCunstomerComments");
            DropTable("dbo.ProcessSettings");
        }
    }
}
