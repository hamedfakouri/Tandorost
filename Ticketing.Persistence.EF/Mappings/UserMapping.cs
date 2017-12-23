using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Persistence.EF.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("User");
            Property(x => x.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.FirstName).HasMaxLength(150);
            Property(x => x.LastName).HasMaxLength(200);

            HasRequired(x => x.Groups).WithMany(x=>x.Users).HasForeignKey(x => x.GroupId);
        }
    }
}
