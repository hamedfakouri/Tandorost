namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClaimPermissionModel : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.ClaimPermisions");
        }
    }
}
