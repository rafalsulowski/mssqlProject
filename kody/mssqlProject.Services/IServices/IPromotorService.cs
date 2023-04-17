using System.Linq.Expressions;
using mssqlProject.Models;

namespace mssqlProject.Services.IServices
{
    public interface IPromoterService
    {
        Task<RepositoryResponse<List<Promoter>>> GetPromotersAsync(Expression<Func<Promoter, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Promoter>> GetPromoterAsync(Expression<Func<Promoter, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreatePromoter(Promoter Promoter);
        Task<RepositoryResponse<bool>> UpdatePromoter(Promoter Promoter);
        Task<RepositoryResponse<bool>> DeletePromoter(Promoter Promoter);
    }
}
