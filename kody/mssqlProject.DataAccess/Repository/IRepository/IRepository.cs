using mssqlProject.Models;
using System.Linq.Expressions;

namespace mssqlProject.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        Task<RepositoryResponse<List<T>>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<T>> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> SaveChangesAsync();
    }
}
