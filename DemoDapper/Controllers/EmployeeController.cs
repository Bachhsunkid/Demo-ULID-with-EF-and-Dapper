using DemoDapper.Model;
using DemoDapper.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Ulid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                return Ok();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            var response = await _employeeService.InsertAsync(employee);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            var response = await _employeeService.UpdateAsync(employee);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Ulid id)
        {
            var response = await _employeeService.DeleteAsync(id);
            return Ok(response);
        }

    }
}
