using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Log;

namespace Ticketing.Persistence.EF.Mappings
{
    public class LogTicketMapping:EntityTypeConfiguration<LogTicket>
    {
        public LogTicketMapping()
        {
            ToTable("LogTickets").HasKey(x => x.Id);

            Property(x => x.DateTime);
            Property(x => x.AuditAction).HasColumnType("int");
            Property(x => x.TicketState);

            HasRequired(x => x.User).WithMany().HasForeignKey(x=>x.UserId);
            HasRequired(x => x.Ticket).WithMany().HasForeignKey(x => x.TicketId);
        }
    }
}
