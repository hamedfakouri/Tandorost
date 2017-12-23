using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Core.Security;
using Ticketing.Domain.Model.Groups;

namespace Ticketing.Application.Contract.Users
{
    public interface IUserService : IApplicationService
    {
        void RegistUser(CreateUserDto dto);
        void AssignDepartmentToUser(AssignDepartmentToUserDto dto);
        void DeleteEmployee(long userId);
        void EditEmployee(UserDto dto);
        ListGetUserDto GetAllUsers();
        //User GetUserBy(string name);
        GetUserDto GetUserBy(long id);
        GetUserDto GetUserById();

        [IgnorePermission]
        List<string> GetUserPermission();

        [IgnorePermission]
        void CheckUserForRegistration();

        List<UserDto> GetUserMemberOnDepartment(long departmentId);
    }
}
