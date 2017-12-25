using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Security;
using Ticketing.Application.Contract.Users;
using Ticketing.Domain.Model.Departments;
using Ticketing.Domain.Model.Users;
using System.Threading;

namespace Ticketing.Application
{
    public class UsersService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public UsersService(IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }

        public void RegistUser(CreateUserDto dto)
        {
            var user = new User(dto.UserId, dto.FirstName, dto.LastName, 1);
            _userRepository.RegistUser(user);
        }
        public void CheckUserForRegistration()
        {
            var userId = long.Parse(ClaimHelper.GetUserId());
            var user = _userRepository.FindUserBy(userId);
            if (user == null)
            {
                var userClaim = ClaimHelper.GetUserClaimsIdentity();
                var fisrtName = userClaim.FindFirst("FirstName").Value;
                var lastName = userClaim.FindFirst("LastName").Value;
                var userInfo = new User(userId, fisrtName, lastName, 1);

                _userRepository.RegistUser(userInfo);
            }
        }

        public void AssignDepartmentToUser(AssignDepartmentToUserDto dto)
        {
            var user = _userRepository.FindUserBy(dto.UserId);
            var department = _departmentRepository.FindBy(dto.DepartmentId);
            user.AssignDepartmentToUser(department);
        }

        public void DeleteEmployee(long userId)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public ListGetUserDto GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            var listGetUserDto = new ListGetUserDto();
            foreach (var user in users)
            {
                var userDto = new GetUserDto()
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Departents = user.Departents
                };
                listGetUserDto.Add(userDto);
            }
            return listGetUserDto;
        }

        public GetUserDto GetUserBy(long id)
        {
            var userId = ClaimHelper.GetUserId();
            var user = _userRepository.FindUserBy(id);
            var getUserDto = new GetUserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Departents = user.Departents
            };
            return getUserDto;
        }

        public GetUserDto GetUserById()
        {
            var userId = long.Parse(ClaimHelper.GetUserId());
            var user = _userRepository.FindUserBy(userId);
            var getUserDto = new GetUserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Departents = user.Departents
            };
            return getUserDto;
        }

        public List<UserDto> GetUserMemberOnDepartment(long departmentId)
        {
            var users = _userRepository.GetUserMemberOnDepartment(departmentId);
            var usersList = new List<UserDto>();
            foreach (var user in users)
            {
                var dto = new UserDto()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                usersList.Add(dto);
            }
            return usersList;
        }

        public List<string> GetUserPermission()
        {
            long Id = 0;
            long.TryParse(ClaimHelper.GetUserId(),out Id);

            var permissions = _userRepository.GetUserPermissionBy(Id);
            return permissions.ToList();
        }
    }
}
