using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticketing.Application.Contract.Department;

namespace Ticketing.Interface.RestApi.Controllers
{
    
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public DepartmentList Get()
        {
            return _departmentService.GetAllDepartments();
        }
    }
}
