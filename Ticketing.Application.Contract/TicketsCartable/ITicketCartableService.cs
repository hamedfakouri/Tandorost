using System.Collections.Generic;
using Framework.Core;
using Framework.Core.Security;
using Ticketing.Application.Contract.Tickets;
using Ticketing.Domain.Model.Groups;
using Ticketing.Domain.Model.TicketsCartable;

namespace Ticketing.Application.Contract.TicketsCartable
{
    public interface ITicketCartableService : IApplicationService
    {
        [HasPermission(TicketingPermission.ReferralTicketCartable)]
        long ReferralTicket(ReferralTicketCartableDto dto);

        [HasPermission(TicketingPermission.ViewCartable)]
        ListTicketCartableDto GetMyCartable();

        [HasPermission(TicketingPermission.ViewTicketComment)]
        ListCommentDto GetMyTicketComment(long ticketId);
    }
}
