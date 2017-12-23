using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Domain.Services.TicketServices
{
    public interface IUserDepartment
    {
        long GetUserThatHaveLeastOpenTicket(long departmentId);
        List<User> GetUserMemperOnUserDepartment(long departmentId);
    }
}
