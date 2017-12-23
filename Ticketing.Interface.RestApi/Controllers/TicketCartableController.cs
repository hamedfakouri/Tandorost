using System.Web.Http;
using Ticketing.Application.Contract.Tickets;
using Ticketing.Application.Contract.TicketsCartable;

namespace Ticketing.Interface.RestApi.Controllers
{
    public class TicketCartableController : ApiController
    {
        private readonly ITicketCartableService _ticketCartableService;

        public TicketCartableController(ITicketCartableService ticketCartableService)
        {
            _ticketCartableService = ticketCartableService;
        }

        public ListCommentDto GetMyTicketComment(long Id)
        {
            var ticketComment= _ticketCartableService.GetMyTicketComment(Id);
            return ticketComment;
        }

        public ListTicketCartableDto GetAllMyTicketCartable()
        { 
            var listTicketDashboardResult = _ticketCartableService.GetMyCartable();
            return listTicketDashboardResult;
        }

        public void PostReferralTicket(ReferralTicketCartableDto dto)
        {
            _ticketCartableService.ReferralTicket(dto);
        }
    }
}
