using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;

namespace Ticketing.Application.Contract.Tickets
{
    public class CommentDto
    {
        public long Id { get; set; }
        public long CurrntUserId { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long TicketId { get; set; }
        public string Comment { get; set; }
        public List<CommentAttachmentDto> CommentAttachments { get; set; }
        public string DateTime { get; set; }

    }
}
