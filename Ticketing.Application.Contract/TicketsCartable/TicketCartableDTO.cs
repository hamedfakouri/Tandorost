using System.Collections.Generic;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;

namespace Ticketing.Application.Contract.TicketsCartable
{
    public class TicketCartableDTO
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string DateTime { get; set; }
        public string TicketState { get; set; }
        public List<CommentAttachment> TicketAttachments{ get; set; }
    }
}
