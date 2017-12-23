using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Domain.Model.Log
{
    public class LogTicket : EntityBase<long>
    {
        public long TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string DateTime { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public TicketState TicketState { get; set; }
        public int AuditAction { get; set; }

        public LogTicket(long ticketId, string dateTime, long userId, TicketState ticketState, int auditAction)
        {
            TicketId = ticketId;
            DateTime = dateTime;
            UserId = userId;
            TicketState = ticketState;
            AuditAction = auditAction;
        }

        public LogTicket()
        {
            
        }
    }
}
