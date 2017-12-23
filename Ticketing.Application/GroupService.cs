using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Contract.Groups;
using Ticketing.Domain.Model.Groups;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Application
{
    public class GroupService:IGroupService
    {
        private readonly IUserRepository _userRepository;

        public GroupService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<string> GetUserGroup(long userId)
        {
            return _userRepository.GetUserPermissionBy(userId);
        }
    }
}
