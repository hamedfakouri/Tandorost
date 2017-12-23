using System.Collections.Generic;
using Framework.Core;

namespace Ticketing.Domain.Model.Users
{
    public interface IUserRepository:IRepository
    {
        void RegistUser(User user);
        void DeleteUser(long userId);
        void EditUser(User user);
        List<User> GetAllUsers();
        User FindUserBy(string name);
        User FindUserBy(long id);
        User FindUserGroupBy(long id);
        IEnumerable<string> GetUserPermissionBy(long id);
        List<User> GetUserMemberOnDepartment(long departmentId);
        long GetUserThatHaveLeastOpenTicket(long departmentId);
       
    }

}
