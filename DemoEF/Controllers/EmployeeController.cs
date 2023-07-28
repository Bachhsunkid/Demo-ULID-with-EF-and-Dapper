using DemoEF.Model;
using DemoEF.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService service)
        {
            _employeeService = service;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _employeeService.GetAllEmployees();
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("id")]
        public IActionResult GetEmployeesById(Ulid id)
        {
            try
            {
                var employees = _employeeService.GetEmployeeById(id);
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult UpsertEmployee(Employee employee)
        {
            try
            {
                var model = _employeeService.UpsertEmployee(employee);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("")]
        public IActionResult DeleteEmployee(Ulid id)
        {
            try
            {
                var model = _employeeService.DeleteEmployee(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
