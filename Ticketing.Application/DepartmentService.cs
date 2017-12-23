using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Contract.Department;
using Ticketing.Domain.Model.Departments;

namespace Ticketing.Application
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Department GetBy(long departmentId)
        {
            throw new NotImplementedException();
        }

        public DepartmentList GetAllDepartments()
        {
            DepartmentList departmentList = new DepartmentList();
            var depList= _departmentRepository.GetAllDepartment();
            foreach (var department in depList)
            {
                var depart=new DepartmentDto()
                {
                    Name=department.Name,
                    Id=department.Id
                };
                departmentList.Add(depart);
            }
            return departmentList;
        }
    }
}
