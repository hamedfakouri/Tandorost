using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticketing.Application.Contract.Tickets;

namespace Ticketing.Interface.RestApi.Controllers
{
    public class UploadResourcesController : ApiController
    {
        private readonly ITicketService _ticketService;
        public UploadResourcesController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public string Post()
        {
            return _ticketService.GetUploadTicketAttachment();
        }
    }
}
