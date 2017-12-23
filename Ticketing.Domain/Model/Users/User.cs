using System.Collections.Generic;
using System.Linq;
using Ticketing.Domain.Model.Departments;
using Ticketing.Domain.Model.Groups;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;

namespace Ticketing.Domain.Model.Users
{
    public class User
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Department> Departents { get; set; }
        public long GroupId { get; set; }
        public Group Groups { get; set; }
        public List<TicketComment> TicketComments { get; set; }
        public List<Ticket> Tickets { get; set; }

        public User()
        {
            
        }
        public User(long userId, string firstName, string lastName,long groupId)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            GroupId = groupId;
        }

        public void AssignDepartmentToUser(Department department)
        {
            this.Departents.Add(department);
        }
    }


}
