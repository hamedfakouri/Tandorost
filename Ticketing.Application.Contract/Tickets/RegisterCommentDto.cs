using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Tickets.TicketComment;

namespace Ticketing.Application.Contract.Tickets
{
    public class RegisterCommentDto
    {
        public long TicketId { get; set; }
        public string Comment { get; set; }
        public List<CommentAttachment> CommentAttachments { get; set; }
    }
}
