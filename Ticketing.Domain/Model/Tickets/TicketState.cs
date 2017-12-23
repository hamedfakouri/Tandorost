using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Domain.Model.Tickets
{
    public enum TicketState
    {
        ThicketCreated=1,
        OpenTicket=2,
        ReOpenTicket=3,
        TicketResolved=4,
        TicketClosed=5,
        AssignedTicket=6
    }
}
