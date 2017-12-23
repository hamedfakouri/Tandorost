using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Departments;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;

namespace Ticketing.Persistence.EF.Mappings
{
    public class TicketCommentMapping : EntityTypeConfiguration<TicketComment>
    {
        public TicketCommentMapping()
        {
            ToTable("TicketComments").HasKey(x=>x.Id);
            Property(x => x.Comment);

            HasRequired(x => x.Ticket)
                .WithMany(x => x.TicketComments)
                .HasForeignKey(x => x.TicketId);
        }
    }
}
