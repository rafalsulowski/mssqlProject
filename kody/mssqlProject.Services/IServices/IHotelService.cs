using System.Linq.Expressions;
using mssqlProject.Models;

namespace mssqlProject.Services.IServices
{
    public interface IHotelService
    {
        Task<RepositoryResponse<List<Hotel>>> GetHotelsAsync(Expression<Func<Hotel, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Hotel>> GetHotelAsync(Expression<Func<Hotel, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateHotel(Hotel Hotel);
        Task<RepositoryResponse<bool>> UpdateHotel(Hotel Hotel);
        Task<RepositoryResponse<bool>> DeleteHotel(Hotel Hotel);
    }
}
