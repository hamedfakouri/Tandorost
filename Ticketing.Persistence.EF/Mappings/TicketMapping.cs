using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Tickets;

namespace Ticketing.Persistence.EF.Mappings
{
    public class TicketMapping:EntityTypeConfiguration<Ticket>
    {
        public TicketMapping()
        {
            ToTable("Ticketslkuyoyoiuy").HasKey(x => x.Id);

            Property(x => x.DateTime);
            Property(x => x.TicketPriority);
            Property(x => x.TicketState);

            HasRequired(x => x.User).WithMany(x=>x.Tickets)
                .HasForeignKey(x => x.CustomerId);

        }
    }
}
