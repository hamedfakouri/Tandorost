using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Core.Security;
using Ticketing.Domain.Model.Groups;

namespace Ticketing.Application.Contract.Department
{
    public interface IDepartmentService:IApplicationService
    {
        [HasPermission(TicketingPermission.ViewDepartmentBy)]
        Domain.Model.Departments.Department GetBy(long departmentId);

        //[HasPermission(TicketingPermission.ViewAllDepartmkent)]
        [IgnorePermission]
        DepartmentList GetAllDepartments();
    }
}
