using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Framework.Domain;
using Ticketing.Application.Contract.LogTicket;

namespace Ticketing.Interface.RestApi.Controllers
{
    public class LogTicketController : ApiController
    {
        private readonly ILogTicketService _logTicketService;

        public LogTicketController(ILogTicketService logTicketService)
        {
            _logTicketService = logTicketService;
        }

        public ListAllUsersLogDto Get(/*long userId, PageModel pageModel*/)
        {
            PageModel pageModel = new PageModel()
            {
                PageIndex = 0,
                PageSize = 20
            };

             var logTicket=_logTicketService.GetAllUsersLog(1, pageModel);
            return logTicket;
        }
    }
}
