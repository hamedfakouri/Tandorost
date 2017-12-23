using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Departments;

namespace Ticketing.Persistence.EF.Mappings
{
    public class DepartmentMapping:EntityTypeConfiguration<Department>
    {
        public DepartmentMapping()
        {
            ToTable("Department").HasKey(x=>x.Id);
            Property(x => x.Name).HasMaxLength(500);

            HasMany(x => x.Users)
                .WithMany(x => x.Departents)
                .Map(a =>
                {
                    a.MapLeftKey("DepartmentId");
                    a.MapRightKey("UserId");
                    a.ToTable("DepartmentUsers");
                });
        }
    }
}
