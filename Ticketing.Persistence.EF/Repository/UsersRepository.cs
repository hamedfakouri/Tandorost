using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Persistence.EF.Repository
{
    public class UsersRepository : IUserRepository
    {
        private readonly TicketingDbContext _context;

        public UsersRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public void RegistUser(User user)
        {
            _context.Users.Add(user);
        }
        public void DeleteUser(long userId)
        {
            var user=_context.Users.SingleOrDefault(x => x.UserId == userId);
            if (user != null) _context.Users.Remove(user);
        }

        public void EditUser(User user)
        {
            var _user = _context.Users.SingleOrDefault(x => x.UserId == user.UserId);
            if (_user != null)
            {
                _user.UserId = user.UserId;
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
            }
        }

        public List<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User FindUserBy(string name)
        {
            return _context.Users.SingleOrDefault(x => x.FirstName == name);
        }

        public User FindUserBy(long id)
        {
            return _context.Users.Include(x=>x.Departents).SingleOrDefault(x => x.UserId == id);
        }
        public User FindUserGroupBy(long id)
        {
            return _context.Users.Where(x => x.UserId == id).Include(x => x.Groups.Permissions).SingleOrDefault();
        }
        public IEnumerable<string> GetUserPermissionBy(long id)
        {
            var permissions= _context.Users.Where(x=>x.UserId==id).Include(x => x.Groups.Permissions)
                .SelectMany(x=>x.Groups.Permissions).ToList();

            return permissions.Select(x => x.TicketingPermissions.ToString()).ToList();
        }

        public List<User> GetUserMemberOnDepartment(long departmentId)
        {
            var userMemberOnDepartmnet = _context.Departments
                .Where(x => x.Id == departmentId).Include(x => x.Users)
                .Select(x => x.Users).ToList();
            var res=new List<User>();
            foreach (var user in userMemberOnDepartmnet)
            {
                res=user.ToList();
            }

            return res /*userMemberOnDepartmnet*/;
        }

        public class UserDto
        {
            public int TicketOpenCount { get; set; }
            public long UserId { get; set; }

        }


        private  List<UserDto> UserDtos = new List<UserDto>();

        public long GetUserThatHaveLeastOpenTicket(long departmentId)
        {
            var userMemberOnDepartmnet = _context.Departments.Include(x => x.Users)
                .Where(x => x.Id == departmentId).Select(x => x.Users).ToList();
            foreach (var users in userMemberOnDepartmnet)
            {
                foreach (var items in users)
                {
                    var usersThatHaveOpenTicket = _context.TicketCartables
                        .Where(x => x.ReciverId == items.UserId
                        && (/*x.Ticket.TicketState == TicketState.OpenTicket ||*/ x.Ticket.TicketState==TicketState.AssignedTicket))
                        .Select(x => new { x.ReciverId })
                        .ToList();

                    UserDtos.Add(new UserDto()
                    {
                        UserId = items.UserId,
                        TicketOpenCount = usersThatHaveOpenTicket.Count
                    });

                }
            }
            var minOpenTicket = UserDtos.Min(x => x.TicketOpenCount);
            //var user = UserDtos.SingleOrDefault(x => x.ticketOpenCount == minOpenTicket);
            var user = UserDtos.Where(x => x.TicketOpenCount == minOpenTicket).ToList();
            long reciverId = 0;
            foreach (var item in user)
            {
                reciverId = item.UserId;
                break;
            }
            return reciverId;
        }

        



    }
}
