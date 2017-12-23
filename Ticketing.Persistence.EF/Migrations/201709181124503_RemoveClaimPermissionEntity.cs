namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveClaimPermissionEntity : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ClaimPermisions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClaimPermisions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RoleName = c.String(),
                        Permission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
