using System.Collections.Generic;
using Framework.Domain;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Domain.Model.Groups
{
    public class Group : EntityBase<long>
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
