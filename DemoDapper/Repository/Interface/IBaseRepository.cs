namespace DemoDapper.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(Ulid id);

        Task<int> InsertAsync(T entity);

        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(Ulid id);
    }
}
