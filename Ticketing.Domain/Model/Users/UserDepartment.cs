using Framework.Domain;
using Ticketing.Domain.Users;

namespace Ticketing.Domain.Model.Users
{
    public class UserDepartment : EntityBase<long>
    {
        public long UserId { get; set; }
        public long DepartmentId { get; set; }

        public User User { get; set; }
        public Department Department { get; set; }
    }

}
