using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Departments;


namespace Ticketing.Persistence.EF.Mappings
{
    public class PermissionMapping : EntityTypeConfiguration<Domain.Model.Groups.Permission>
    {
        public PermissionMapping()
        {
            ToTable("Permissions").HasKey(x => x.Id);
            Property(x => x.TicketingPermissions);

            HasRequired(x => x.Groups).WithMany(x => x.Permissions)
                .HasForeignKey(x => x.GroupId);
        }
    }
}
