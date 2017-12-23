using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Tickets;

namespace Ticketing.Application.Contract.Tickets
{
    public class TicketDto
    {
        public long Id { get; set; }
        public long CurrntUserId { get; set; }
        public string Comment { get; set; }
        public string DateTime { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TicketState { get; set; }
        public string TicketPriority { get; set; }
    }
}
