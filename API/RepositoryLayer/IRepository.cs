using DomainLayer;
using System.Linq.Expressions;

namespace RepositoryLayer
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IAsyncEnumerable<T>> GetAllAsync();
        Task<T> GetOneAsync(int id);
        Task InsertOneAsync(T entity);
        Task UpdateOneAsync(T entity);
        Task DeleteOneAsync(int id);
        Task<IAsyncEnumerable<T>> GeneralSearchAsync(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();

    }
}
