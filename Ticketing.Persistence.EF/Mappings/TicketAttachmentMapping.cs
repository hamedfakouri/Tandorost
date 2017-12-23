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
    public class TicketAttachmentMapping : EntityTypeConfiguration<CommentAttachment>
    {
        public TicketAttachmentMapping()
        {
            ToTable("CommentAttachments").HasKey(x=>x.Id);
            Property(x => x.DateTime);
            Property(x => x.FileUri);
            Property(x => x.FileName);
            Property(x => x.FileSize);

            HasRequired(x => x.TicketComment)
                .WithMany(x => x.CommentAttachments)
                .HasForeignKey(x => x.TicketCommentId);
        }
    }
}
