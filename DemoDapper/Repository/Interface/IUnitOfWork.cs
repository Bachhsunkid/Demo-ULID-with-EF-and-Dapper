namespace DemoDapper.Repository.Interface
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
    }
}
