using DemoDapper.Model;
using DemoDapper.Repository.Interface;
using DemoDapper.Service.Interface;

namespace DemoDapper.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            return await _unitOfWork.Employees.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(Ulid id)
        {
            return await _unitOfWork.Employees.GetByIdAsync(id);
        }

        public async Task<ResponseAPI> InsertAsync(Employee employee)
        {
            var response = new ResponseAPI();
            try
            {
                employee.Id = Ulid.NewUlid();
                var rowAffected = await _unitOfWork.Employees.InsertAsync(employee);

                if (rowAffected > 0)
                {
                    response.IsSuccess = true;
                    response.Message = "Inserted successfully!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Insert failed!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseAPI> UpdateAsync(Employee employee)
        {
            var response = new ResponseAPI();
            try
            {
                var rowAffected = await _unitOfWork.Employees.UpdateAsync(employee);

                if (rowAffected > 0)
                {
                    response.IsSuccess = true;
                    response.Message = "Updated successfully!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Update failed!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseAPI> DeleteAsync(Ulid id)
        {
            var response = new ResponseAPI();
            try
            {
                var rowAffected = await _unitOfWork.Employees.DeleteAsync(id);

                if (rowAffected > 0)
                {
                    response.IsSuccess = true;
                    response.Message = "Deleted successfully!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Delete failed!";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }

    }
}
