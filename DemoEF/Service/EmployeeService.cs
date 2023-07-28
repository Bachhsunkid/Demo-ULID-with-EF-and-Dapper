using DemoEF.Data;
using DemoEF.Model;
using DemoEF.Service.Interface;

namespace DemoEF.Service
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = _context.Set<Employee>().ToList();
            employees.Sort((emp1, emp2) => emp2.Id.CompareTo(emp1.Id)); //auto sort by created date when get all
            return employees;
        }

        public Employee GetEmployeeById(Ulid id)
        {
            Employee employee;
            try
            {
                employee = _context.Find<Employee>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return employee;
        }

        public ResponseAPI UpsertEmployee(Employee employee)
        {
            ResponseAPI response = new ResponseAPI();
            try
            {
                Employee emp = GetEmployeeById(employee.Id);
                if (emp != null)
                {
                    emp.Designation = employee.Designation;
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.Salary = employee.Salary;
                    _context.Update<Employee>(emp);
                    response.Message = "Employee Update Successfully";
                }
                else
                {
                    employee.Id = Ulid.NewUlid();
                    _context.Add<Employee>(employee);
                    response.Message = "Employee Inserted Successfully";
                }
                _context.SaveChanges();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error : " + ex.Message;
            }
            return response;
        }

        public ResponseAPI DeleteEmployee(Ulid id)
        {
            ResponseAPI response = new ResponseAPI();
            try
            {
                Employee emp = GetEmployeeById(id);
                if (emp != null)
                {
                    _context.Remove<Employee>(emp);
                    _context.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Employee Deleted Successfully";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Employee Not Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error : " + ex.Message;
            }
            return response;
        }
    }
}
