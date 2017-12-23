using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.DataAccess.EF;
using Framework.Domain;

namespace Ticketing.Application.Contract.LogTicket
{
    public interface ILogTicketService:IApplicationService
    {
        //void RegistLogTicket();
        void Delete(long logId);
        Domain.Model.Log.LogTicket GetBy(long logId);
        ListAllUsersLogDto GetAllUsersLog(long userId, PageModel pageModel);
        List<Domain.Model.Log.LogTicket> GetAllLog(PageModel pageModel);

    }
}
