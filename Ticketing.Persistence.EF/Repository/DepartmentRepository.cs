using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model.Departments;

namespace Ticketing.Persistence.EF.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly TicketingDbContext _context;

        public DepartmentRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public void Regist(Department department)
        {
            _context.Departments.Add(department);
        }

        public void Delete(long departmentId)
        {
            var department = _context.Departments.SingleOrDefault(x => x.Id == departmentId);
            if (department != null) _context.Departments.Remove(department);
        }

        public void Edit(Department department)
        {
            var depart = _context.Departments.SingleOrDefault(x => x.Id == department.Id);
            if (depart != null)
                depart.Name = department.Name;
        }

        public Department FindBy(long departmentId)
        {
            return _context.Departments.SingleOrDefault(x => x.Id == departmentId);
        }

        public List<Department> GetAllDepartment()
        {
            return _context.Departments.OrderBy(x => x.Name)
                .Skip(0).Take(10).ToList();
        }
    }
}
