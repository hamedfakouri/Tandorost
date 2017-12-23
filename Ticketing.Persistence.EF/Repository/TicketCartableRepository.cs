using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;
using Ticketing.Domain.Model.TicketsCartable;

namespace Ticketing.Persistence.EF.Repository
{
    public class TicketCartableRepository : ITicketCartableRepository
    {
        private readonly TicketingDbContext _context;

        public TicketCartableRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public TicketCartable LastTicketThatTicketAssinedEqualToTrue(long ticketId)
        {
              return _context.TicketCartables.SingleOrDefault(x => x.TicketId == ticketId 
                                                                && x.TicketAssigned == true);
        }

        public Ticket FindTicket(long ticketId)
        {
            return _context.Tickets.SingleOrDefault(x => x.Id == ticketId);
        }
        public long ReferralTicket(TicketCartable ticketDashboard)
        {
            _context.TicketCartables.Add(ticketDashboard);
            return ticketDashboard.Id;
        }
        public List<TicketComment> GetMyTicketComment(long ticketId)
        {
            var myTicketCartable = _context.TicketComments
                .Where(x => x.TicketId == ticketId).Include(x=>x.CommentAttachments).Include(x=>x.Users).ToList();

            //var myTicketCartable1 = _context.TicketComments
            //    .Where(x => x.TicketId == ticketId).Include(x => x.CommentAttachments).Include(x => x.Users)
            //    .AsQueryable();

            //if (myTicketCartable != null && myTicketCartable.Ticket.TicketState == TicketState.AssignedTicket
            //    /*&& myTicketDashboard.Ticket.CustomerId.ToString() != currentUser.ToString()*/)
            //    myTicketCartable.Ticket.TicketState = TicketState.OpenTicket;

            //if (myTicketDashboard != null && myTicketDashboard.Ticket.TicketState == TicketState.TicketClosed 
            //    && myTicketDashboard.Ticket.CustomerId.ToString() == currentUser.ToString())
            //    myTicketDashboard.Ticket.TicketState = TicketState.OpenTicket;

            return myTicketCartable;
        }

        public List<TicketCartable> GetMyTicketsCartables(long userId)
        {
            return _context.TicketCartables.Where(x => x.ReciverId == userId
                                                        && x.Ticket.TicketState != TicketState.TicketClosed
                                                        && x.TicketAssigned == true)
                                                        .Include(x => x.Ticket.TicketComments)
                                                        .Include(x=>x.Ticket.User).ToList();
        }
    }
}
