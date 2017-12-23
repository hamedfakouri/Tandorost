using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Core.Security;
using Ticketing.Domain.Model.Groups;
using Ticketing.Domain.Model.Tickets;

namespace Ticketing.Application.Contract.Tickets
{
    public interface ITicketService : IApplicationService
    {
        [HasPermission(TicketingPermission.RegisterTicket)]
        void RegistTicket(CreateTicketDto dto);

        [HasPermission(TicketingPermission.DeleteTicketComment)]
        void DeleteComment(long ticketId);

        [HasPermission(TicketingPermission.WriteTicketComment)]
        void WriteTicketComment(RegisterCommentDto dto);

        [HasPermission(TicketingPermission.ViewTicket)]
        List<Ticket> GetTicketsForCustomer(long userId);

        [IgnorePermission]
        void MarkAsOpenTicketInCartable(long ticketId);

        [HasPermission(TicketingPermission.ViewTicket)]
        Task<ListTicketDto> GetMyTicket();

        [HasPermission(TicketingPermission.DeleteTicket)]
        void Delete(long ticketId);

        [HasPermission(TicketingPermission.RegisterTicket)]
        string GetUploadTicketAttachment();

        [HasPermission(TicketingPermission.CloseTicket)]
        void ChangeStateToCloseTicket(long id);
    }
}
