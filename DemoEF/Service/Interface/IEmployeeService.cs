using DemoEF.Model;

namespace DemoEF.Service.Interface
{
    public interface IEmployeeService
    {
        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns></returns>
        List<Employee> GetAllEmployees();

        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        Employee GetEmployeeById(Ulid id);

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        ResponseAPI UpsertEmployee(Employee employee);


        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        ResponseAPI DeleteEmployee(Ulid id);
    }
}
