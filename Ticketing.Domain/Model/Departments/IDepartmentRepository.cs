using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;

namespace Ticketing.Domain.Model.Departments
{
    public interface IDepartmentRepository:IRepository
    {
        void Regist(Department department);
        void Delete(long departmentId);
        void Edit(Department department);

        Department FindBy(long departmentId);
        List<Department> GetAllDepartment();
    }
}
