using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DataAccess.EF;
using Framework.Domain;
using Ticketing.Application.Contract.LogTicket;
using Ticketing.Domain.Model.Log;

namespace Ticketing.Application
{
    public class LogTicketService : ILogTicketService
    {
        private readonly ILogTicketRepository _logTicketRepository;
        public LogTicketService(ILogTicketRepository logTicketRepository)
        {
            _logTicketRepository = logTicketRepository;
        }

        public void Delete(long logId)
        {
            _logTicketRepository.Delete(logId);
        }

        public LogTicket GetBy(long logId)
        {
            return _logTicketRepository.GetBy(logId);
        }

        public ListAllUsersLogDto GetAllUsersLog(long userId, PageModel pageModel)
        {
            var ticketsLogThatReferralToUser = _logTicketRepository.GetAllUsersLog(userId, pageModel);

            ListAllUsersLogDto allUsersLogDtos = new ListAllUsersLogDto();
            foreach (var logTicket in ticketsLogThatReferralToUser)
            {
                var allUsersLogDto=new AllUsersLogDto()
                {
                    DateTime=logTicket.DateTime,
                    TicketState = logTicket.TicketState,
                    AuditAction = logTicket.AuditAction,
                    FisrtNameOfUserThatRegistATicket =logTicket.Ticket.User.FirstName,
                    LastNameOfUserThatRegistATicket = logTicket.Ticket.User.LastName,
                    CustomerTicketComment = logTicket.Ticket.User.TicketComments,

                    FisrtNameOfUserThatResponseToTicket = logTicket.User.FirstName,
                    LastNameOfUserThatResponseToTicket = logTicket.User.LastName,
                    EmployeeTicketComment=logTicket.User.TicketComments
                };
                allUsersLogDtos.Add(allUsersLogDto);
            }
            return allUsersLogDtos;
        }

        public List<LogTicket> GetAllLog(PageModel pageModel)
        {
            return _logTicketRepository.GetAllLog(pageModel);
        }
    }
}
