using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specfications.EmployeeSpec;
using Talabat.Errors;

namespace Talabat.Controllers
{

    public class EmployeeController : BaseApiController
    {
        private readonly IGenaricRepository<Employee> _employeeRepo;

        public EmployeeController(IGenaricRepository<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GrtEmployees()
        {
            var spec = new EmployeeWithDeptSpec();

            var employees = await _employeeRepo.GetAllWithSpecAsync(spec);

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var spec = new EmployeeWithDeptSpec(id);

            var employee = await _employeeRepo.GetWithSpec(spec);

            if (employee == null)
                return NotFound(new ApiResponse(404));

            return Ok(employee);
        }
    }
}
