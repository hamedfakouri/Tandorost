using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DataAccess.EF;
using Framework.Domain;
using Ticketing.Domain.Model.Log;

namespace Ticketing.Persistence.EF.Repository
{
    public class LogTicketRepository: ILogTicketRepository
    {
        private readonly TicketingDbContext _context;

        public LogTicketRepository(TicketingDbContext context)
        {
            _context = context;
        }
        public void Delete(long logId)
        {
            var logTicket = _context.LogTickets.SingleOrDefault(x => x.Id == logId);
            if (logTicket != null) _context.LogTickets.Remove(logTicket);
        }

        public LogTicket GetBy(long logId)
        {
            var logTicket = _context.LogTickets.SingleOrDefault(x => x.Id == logId);
            return logTicket;
        }

        public List<LogTicket> GetAllUsersLog(long userId,PageModel pageModel)
        {
            var logTickets = _context.LogTickets.Where(x => x.UserId == userId)
                .Include(x=>x.User)
                .Include(x=>x.Ticket.TicketComments)
                .Include(x=>x.Ticket.User)
                .OrderBy(x=>x.DateTime).Skip(pageModel.PageIndex * pageModel.PageSize)
                .Take(pageModel.PageSize).ToList();

            return logTickets;
        }

        public List<LogTicket> GetAllLog(PageModel pageModel)
        {
            var logTickets=_context.LogTickets.OrderBy(x=>x.DateTime)
                .Skip(pageModel.PageIndex * pageModel.PageSize)
                .Take(pageModel.PageSize).ToList();

            return logTickets;
        }
    }
}
