using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.ProcessSettings;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Domain.Services.TicketServices
{
    public class UserDepartment:IUserDepartment
    {
        private readonly IUserRepository _repository;

        public UserDepartment(IUserRepository repository)
        {
            _repository = repository;
        }
        
        public long GetUserThatHaveLeastOpenTicket(long departmentId)
        {
             return _repository.GetUserThatHaveLeastOpenTicket(departmentId);
        }

        public List<User> GetUserMemperOnUserDepartment(long departmentId)
        {
           return _repository.GetUserMemberOnDepartment(departmentId);
        }
    }
}
