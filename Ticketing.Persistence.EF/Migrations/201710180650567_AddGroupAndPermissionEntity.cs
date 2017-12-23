namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupAndPermissionEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        GroupId = c.Long(nullable: false),
                        TicketingPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: false)
                .Index(t => t.GroupId);
            
            AddColumn("dbo.User", "GroupId", c => c.Long(nullable: false));
            CreateIndex("dbo.User", "GroupId");
            AddForeignKey("dbo.User", "GroupId", "dbo.Groups", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Permissions", "GroupId", "dbo.Groups");
            DropIndex("dbo.Permissions", new[] { "GroupId" });
            DropIndex("dbo.User", new[] { "GroupId" });
            DropColumn("dbo.User", "GroupId");
            DropTable("dbo.Permissions");
            DropTable("dbo.Groups");
        }
    }
}
