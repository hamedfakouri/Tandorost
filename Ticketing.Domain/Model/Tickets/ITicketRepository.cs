using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Ticketing.Domain.Model.ProcessSettings;
using Ticketing.Domain.Model.Tickets.TicketComment;

namespace Ticketing.Domain.Model.Tickets
{
    public interface ITicketRepository: IRepository
    {
        long CreateTicket(Ticket ticket);
        //Task<Ticket> OpenMyTicketBy(long ticketId,long currentUserId);
        List<Ticket> GetTicketsForCustomer(long userId);
        //Ticket GetBy(long ticketId);
        Task<List<Ticket>> GetMyTicket(long userId);

        Ticket GetBy(long ticketId);
        void Delete(long ticketId);
        

        ////// For TicketComment ////////////////

        //long CreateTicketComment(TicketComment ticketComment);
        //long EditTicketComment(TicketComment ticketComment);
        //void DeleteTicketComment(long id);
        //List<TicketComment> GetAllTicketComments();
        //List<TicketComment> GeTTicketCommentsBy(long ticketCommentId);

        ////// For TicketAttachmen
        ///  ////////////////

        //long CreateTicketAttachment(TicketAttachment ticketAttachment);
        //long EditTicketAttachmentt(TicketAttachment ticketAttachment);
        //void DeleteTicketAttachment(long id);
        //List<TicketAttachment> GetAllTicketAttachment();
        //List<CommentAttachment> FindCommentAttachmentBy(long commenId);
    }
}
