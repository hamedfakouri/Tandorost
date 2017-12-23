using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Departments;
using Group = Ticketing.Domain.Model.Groups.Group;


namespace Ticketing.Persistence.EF.Mappings
{
    public class GroupMapping : EntityTypeConfiguration<Group>
    {
        public GroupMapping()
        {
            ToTable("Groups").HasKey(x => x.Id);
            Property(x => x.Name).HasMaxLength(500);
        }
    }
}
