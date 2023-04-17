using System.Linq.Expressions;
using mssqlProject.Models;

namespace mssqlProject.Services.IServices
{
    public interface IBudgetService
    {
        Task<RepositoryResponse<List<Budget>>> GetBudgetsAsync(Expression<Func<Budget, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Budget>> GetBudgetAsync(Expression<Func<Budget, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateBudget(Budget Budget);
        Task<RepositoryResponse<bool>> UpdateBudget(Budget Budget);
        Task<RepositoryResponse<bool>> DeleteBudget(Budget Budget);
    }
}
