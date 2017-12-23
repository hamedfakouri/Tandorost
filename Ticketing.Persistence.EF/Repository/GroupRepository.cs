using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Groups;

namespace Ticketing.Persistence.EF.Repository
{
    public class GroupRepository:IGroupRepository
    {
        private readonly TicketingDbContext _context;
        public GroupRepository(TicketingDbContext context)
        {
            _context = context;
        }
        public List<Group> GetGroups()
        {
            throw new NotImplementedException();
        }
        public void RegisterGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public void RemoveGroup(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateGroup(long id)
        {
            throw new NotImplementedException();
        }
    }
}
