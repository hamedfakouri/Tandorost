using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Ticketing.Application.Contract.Users;

namespace Ticketing.Interface.RestApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public List<UserDto> Get(long id)
        {
            return _userService.GetUserMemberOnDepartment(id);
        }

        public void Post(AssignDepartmentToUserDto dto)
        {
            _userService.AssignDepartmentToUser(dto);
        }
        public void PostCheckUserForRegistration(UserDto dto)
        {
            _userService.CheckUserForRegistration();
        }
        public List<string> GetUserPermissionBy()
        {
            var res= _userService.GetUserPermission();
            return res;
        }
    }
}
