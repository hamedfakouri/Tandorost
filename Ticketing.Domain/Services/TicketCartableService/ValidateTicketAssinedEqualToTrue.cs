using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.TicketsCartable;

namespace Ticketing.Domain.Services.TicketCartableService
{
    public class ValidateTicketAssinedEqualToTrue : IValidateTicketAssinedEqualToTrue
    {
        private readonly ITicketCartableRepository _ticketCartableRepository;
        private readonly ITicketRepository _ticketRepository;
        public ValidateTicketAssinedEqualToTrue(ITicketCartableRepository ticketCartableRepository
            ,ITicketRepository ticketRepository)
        {
            _ticketCartableRepository = ticketCartableRepository;
            _ticketRepository = ticketRepository;
        }

        public void LastTicketEqualToFalseAndTicketAssined(long ticketId)
        {
            var lastTicketThatTicketAssinedEqualToTrue =
                _ticketCartableRepository.LastTicketThatTicketAssinedEqualToTrue(ticketId);

            if (lastTicketThatTicketAssinedEqualToTrue != null)
                lastTicketThatTicketAssinedEqualToTrue.TicketAssigned = false;

            var ticket = _ticketRepository.GetBy(ticketId);

            if (ticket != null) ticket.TicketState = TicketState.AssignedTicket;
        }
    }
}
