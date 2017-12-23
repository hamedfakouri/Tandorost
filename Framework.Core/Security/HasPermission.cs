using System;

namespace Framework.Core.Security
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HasPermission:Attribute
    {
        //public TicketingPermission Permission { get; private set; }

        //public HasPermission(TicketingPermission permission)
        //{
        //    Permission = permission;
        //}
        public string Permission { get; private set; }

        public HasPermission(object permission)
        {
            Permission =permission.ToString();
        }

    }
}
