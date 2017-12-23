using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ticketing.Application.Contract.Tickets;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;

namespace Ticketing.Interface.RestApi.Controllers
{
    public class TicketController : ApiController
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public void PostMarkAsReadTicket(MarkAsReadTicketDto dto)
        {
            _ticketService.MarkAsOpenTicketInCartable(dto.TicketId);
        }
        public CreateTicketDto Get()
        {
            return null;
        }
        public void DeleteComment(long Id)
        {
            _ticketService.DeleteComment(Id);
        }

        public void Post(CreateTicketDto dto)
        {
            _ticketService.RegistTicket(dto);
        }
        public void Post(RegisterCommentDto dto)
        {
            _ticketService.WriteTicketComment(dto);
        }
        public async Task<ListTicketDto> GetMyTicket(ListTicketDto dto)
        {
             return await _ticketService.GetMyTicket();
        }
        public void PostchangeStateTicketToClose(CloseTicketDto dto)
        {
            _ticketService.ChangeStateToCloseTicket(dto.TicketId);
        }
    }
}
