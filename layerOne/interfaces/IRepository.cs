using layerOne.models;
using System.Linq.Expressions;

namespace layerOne.interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<User, object>>[] includes);
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
