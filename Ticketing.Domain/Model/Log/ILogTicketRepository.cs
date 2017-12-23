using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Domain;

namespace Ticketing.Domain.Model.Log
{
    public interface ILogTicketRepository:IRepository
    {
        //void Regist(LogTicket logTicket);
        void Delete(long logId);

        LogTicket GetBy(long logId);
        List<LogTicket> GetAllUsersLog(long userId, PageModel pageModel);
        List<LogTicket> GetAllLog(PageModel pageModel);

    }
}
