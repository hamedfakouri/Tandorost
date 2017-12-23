using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.TicketsCartable;

namespace Ticketing.Domain.Services.TicketCartableService
{
    public interface IValidateTicketAssinedEqualToTrue
    {
        void LastTicketEqualToFalseAndTicketAssined(long ticketId);
    }
}
