using System.Collections.Generic;
using Framework.Core;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;

namespace Ticketing.Domain.Model.TicketsCartable
{
    public interface ITicketCartableRepository : IRepository
    {
        long ReferralTicket(TicketCartable ticketDashboard);
        List<TicketComment> GetMyTicketComment(long ticketId);
        List<TicketCartable> GetMyTicketsCartables(long userId);
        TicketCartable LastTicketThatTicketAssinedEqualToTrue(long ticketId);
    }
}
