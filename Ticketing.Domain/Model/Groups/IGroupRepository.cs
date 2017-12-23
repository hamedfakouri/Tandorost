
using System.Collections.Generic;

namespace Ticketing.Domain.Model.Groups
{
    public interface IGroupRepository
    {
        List<Group> GetGroups();
        void RegisterGroup(Groups.Group group);
        void RemoveGroup(long id);
        void UpdateGroup(long id);
    }
}
