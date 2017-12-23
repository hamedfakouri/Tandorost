using Ticketing.Domain.Model.Tickets;

namespace Ticketing.Application.Contract.LogTicket
{
    public class LogTicketDto
    {
        public long TicketId { get; set; }
        public string DateTime { get; set; }
        public long UserId { get; set; }
        public TicketState TicketState { get; set; }
        public int AuditAction { get; set; }
    }
}
