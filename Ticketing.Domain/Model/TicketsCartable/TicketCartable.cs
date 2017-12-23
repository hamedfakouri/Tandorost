using Framework.Domain;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Services.TicketCartableService;
using Ticketing.Domain.Services.TicketServices;

namespace Ticketing.Domain.Model.TicketsCartable
{
    public class TicketCartable : EntityBase<long>
    {
        public string Description { get; set; }
        public long TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string DateTime { get; set; }
        public long SenderId { get; set; }
        public long ReciverId { get; set; }
        public bool TicketAssigned { get; set; }

        public TicketCartable()
        {

        }
        public TicketCartable(string description, long departmentId, IUserDepartment findUserThatHaveLeastOpenTicket
            , long senderId, string dateTime, long ticketId,bool ticketAssigned)
        {
            var reciverId = findUserThatHaveLeastOpenTicket.GetUserThatHaveLeastOpenTicket(departmentId);

            Description = description;
            TicketId = ticketId;
            SenderId = senderId;
            ReciverId = reciverId;
            DateTime = dateTime;
            TicketAssigned = ticketAssigned;
        }
        public TicketCartable(string description, long ticketId, long senderId, string dateTime,
            long reciverId, TicketState ticketState,
            IValidateTicketAssinedEqualToTrue validateTicketAssinedEqualToTrue, bool ticketAssigned)
        {
            validateTicketAssinedEqualToTrue.LastTicketEqualToFalseAndTicketAssined(ticketId);
            Description = description;
            TicketId = ticketId;
            SenderId = senderId;
            ReciverId = reciverId;
            DateTime = DateTime;
            // TicketState = ticketState;
            TicketAssigned = ticketAssigned;
        }

        public void ChangeStateToOpenTicket()
        {
            if (this.Ticket.TicketState == TicketState.AssignedTicket)
                this.Ticket.TicketState = TicketState.OpenTicket;
        }
    }
}
