using System.Collections.Generic;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;

namespace Ticketing.Application.Contract.LogTicket
{
    public class AllUsersLogDto
    {
        public string DateTime { get; set; }
        public int AuditAction { get; set; }
        public string FisrtNameOfUserThatRegistATicket { get; set; }
        public string LastNameOfUserThatRegistATicket { get; set; }
        public List<TicketComment> CustomerTicketComment { get; set; }

        public string FisrtNameOfUserThatResponseToTicket { get; set; }
        public string LastNameOfUserThatResponseToTicket { get; set; }
        public List<TicketComment> EmployeeTicketComment { get; set; }

        public TicketState TicketState { get; set; }
    }
}
