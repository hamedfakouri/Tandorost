using Ticketing.Domain.Model.Tickets;

namespace Ticketing.Application.Contract.TicketsCartable
{
    public class ReferralTicketCartableDto
    {
        public string Description { get; set; }
        public long TicketId { get; set; }
        public long SenderId { get; set; }
        public long ReciverId { get; set; }
        public string DateTime { get; set; }
        public TicketState TicketState { get; set; }
    }
}
