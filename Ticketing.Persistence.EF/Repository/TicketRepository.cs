using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;

namespace Ticketing.Persistence.EF.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketingDbContext _context;

        public TicketRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public long CreateTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            return ticket.Id;
        }

        public async Task<List<TicketComment>> OpenTicketComment(long ticketId)
        {
            var myComment = await _context.TicketComments.Where(x => x.TicketId == ticketId)
                .Include(x => x.CommentAttachments).ToListAsync();
    
            return myComment;
        }

        public async Task<List<Ticket>> GetMyTicket(long userId)
        {
            var myComment = await _context.Tickets.Where(x => x.CustomerId == userId)
                .Include(x => x.TicketComments.Select(z=>z.CommentAttachments))
                .ToListAsync();

            var myComment1 =  _context.Tickets.Where(x => x.CustomerId == userId)
                .Include(x => x.TicketComments)
                .AsQueryable();

            return myComment;
        }

        public Ticket GetBy(long ticketId)
        {
            var myTicket =  _context.Tickets.Include(x=>x.TicketComments)
                .SingleOrDefault(x => x.Id == ticketId);
            return myTicket;
        }
        //public Ticket GetBy(long ticketId)
        //{
        //    return _context.Tickets.SingleOrDefault(x => x.Id == ticketId);
        //}

        public void Delete(long ticketId)
        {
            var ticket = _context.Tickets.SingleOrDefault(x => x.Id == ticketId);
            if (ticket != null) _context.Tickets.Remove(ticket);
        }

        public List<Ticket> GetTicketsForCustomer(long userId)
        {
            return _context.Tickets.Where(x => x.CustomerId == userId)
                .Include(x=>x.TicketComments).ToList();
        }

        /// <summary>
        /// ticketComment Repository Because Tis Is One Agreggate
        /// </summary>
        /// <param name="ticketComment"></param>
        /// <returns></returns>
        //public long CreateTicketComment(TicketComment ticketComment)
        //{
        //    var ticketCommnet = _context.TicketComments.Add(ticketComment);
        //    return ticketCommnet.Id;
        //}

        //public long EditTicketComment(TicketComment ticketComment)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteTicketComment(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<TicketComment> GetAllTicketComments()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<TicketComment> GeTTicketCommentsBy(long ticketCommentId)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// TicketAttachment Repository Because Tis Is One Agreggate
        ///// </summary>
        ///// <param name="TicketAttachment"></param>
        ///// <returns></returns>
        //public long CreateTicketAttachment(TicketAttachment ticketAttachment)
        //{
        //    throw new NotImplementedException();
        //}

        //public long EditTicketAttachmentt(TicketAttachment ticketAttachment)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteTicketAttachment(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<TicketAttachment> GetAllTicketAttachment()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<TicketAttachment> GeTTicketAttachmentBy(long ticketAttachmentId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
