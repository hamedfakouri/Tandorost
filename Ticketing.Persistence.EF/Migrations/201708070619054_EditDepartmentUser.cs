namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDepartmentUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DepartmentUsers", name: "UserId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.DepartmentUsers", name: "DepartmentId", newName: "UserId");
            RenameColumn(table: "dbo.DepartmentUsers", name: "__mig_tmp__0", newName: "DepartmentId");
            RenameIndex(table: "dbo.DepartmentUsers", name: "IX_UserId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.DepartmentUsers", name: "IX_DepartmentId", newName: "IX_UserId");
            RenameIndex(table: "dbo.DepartmentUsers", name: "__mig_tmp__0", newName: "IX_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.DepartmentUsers", name: "IX_DepartmentId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.DepartmentUsers", name: "IX_UserId", newName: "IX_DepartmentId");
            RenameIndex(table: "dbo.DepartmentUsers", name: "__mig_tmp__0", newName: "IX_UserId");
            RenameColumn(table: "dbo.DepartmentUsers", name: "DepartmentId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.DepartmentUsers", name: "UserId", newName: "DepartmentId");
            RenameColumn(table: "dbo.DepartmentUsers", name: "__mig_tmp__0", newName: "UserId");
        }
    }
}
