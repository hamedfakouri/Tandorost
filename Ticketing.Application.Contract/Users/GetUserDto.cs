using System.Collections.Generic;

namespace Ticketing.Application.Contract.Users
{
    public class GetUserDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Domain.Model.Departments.Department> Departents { get; set; }
    }
}