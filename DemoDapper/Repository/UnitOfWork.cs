using DemoDapper.Repository.Interface;

namespace DemoDapper.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IEmployeeRepository employeeRepository)
        {
            Employees = employeeRepository;
        }
        public IEmployeeRepository Employees { get; }
    }
}
