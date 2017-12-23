using Framework.Domain;
using Ticketing.Domain.Model.Groups;

namespace Ticketing.Domain.Model.Groups
{
    public class Permission : EntityBase<long>
    {
        public long GroupId { get; set; }
        public Group Groups { get; set; }
        public TicketingPermission TicketingPermissions { get; set; }
    }
}
