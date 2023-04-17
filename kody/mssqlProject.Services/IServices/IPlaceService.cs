using System.Linq.Expressions;
using mssqlProject.Models;

namespace mssqlProject.Services.IServices
{
    public interface IPlaceService
    {
        Task<RepositoryResponse<List<Place>>> GetPlacesAsync(Expression<Func<Place, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Place>> GetPlaceAsync(Expression<Func<Place, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreatePlace(Place Place);
        Task<RepositoryResponse<bool>> UpdatePlace(Place Place);
        Task<RepositoryResponse<bool>> DeletePlace(Place Place);
    }
}
