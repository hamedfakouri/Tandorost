using System.Collections.Generic;
using Ticketing.Domain.Model;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;

namespace Ticketing.Application.Contract.Tickets
{
    public class CreateTicketDto
    {
        public string AttachmentFileUri { get; set; }
        public string AttachmentFileName { get; set; }
        public long TicketId { get; set; }
        public long DepartmentId { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketState  TicketState { get; set; }
        public List<CommentAttachment> TicketAttachments { get; set; }
        public string Comment { get; set; }

    }
}
