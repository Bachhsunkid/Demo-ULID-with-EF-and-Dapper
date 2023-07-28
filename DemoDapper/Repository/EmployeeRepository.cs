using Dapper;
using DemoDapper.Model;
using DemoDapper.Repository.Interface;
using Microsoft.Data.SqlClient;

namespace DemoDapper.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            var sql = "SELECT * FROM Employees";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Employee>(sql);
                return result.ToList();
            }
        }

        public async Task<Employee> GetByIdAsync(Ulid id)
        {
            var sql = "SELECT * FROM Employees WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConStr")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Employee>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> InsertAsync(Employee employee)
        {
            var sql = "Insert into Employees VALUES (@Id,@FirstName,@LastName,@Salary,@Designation)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConStr")))
            {
                connection.Open();
                employee.Id = Ulid.NewUlid();
                var result = await connection.ExecuteAsync(sql, employee);
                return result;
            }
        }

        public async Task<int> UpdateAsync(Employee entity)
        {
            var sql = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Salary = @Salary, Designation = @Designation  WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConStr")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(Ulid id)
        {
            var sql = "DELETE FROM Employees WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConStr")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }
    }
}
