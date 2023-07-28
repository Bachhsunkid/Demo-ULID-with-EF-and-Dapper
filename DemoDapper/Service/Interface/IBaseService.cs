using DemoDapper.Model;

namespace DemoDapper.Service.Interface
{
    public interface IBaseService<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(Ulid id);

        Task<ResponseAPI> InsertAsync(T entity);

        Task<ResponseAPI> UpdateAsync(T entity);

        Task<ResponseAPI> DeleteAsync(Ulid id);
    }
}
