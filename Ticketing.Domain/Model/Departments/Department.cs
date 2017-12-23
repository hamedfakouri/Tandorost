using System.Collections.Generic;
using Framework.Domain;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Domain.Model.Departments
{
    public class Department:EntityBase<long>
    {
        //public long DepartmentId { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Department(string name)
        {
            Name = name;
        }

        public Department()
        {
        }
    }


}
