using System.Linq.Expressions;
using mssqlProject.Models;
using mssqlProject.Models.DTO;

namespace mssqlProject.Services.IServices
{
    public interface ITripService
    {
        Task<RepositoryResponse<List<Trip>>> GetTripsAsync(Expression<Func<Trip, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Trip>> GetTripAsync(Expression<Func<Trip, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateTrip(Trip Trip);
        Task<RepositoryResponse<bool>> UpdateTrip(Trip Trip);
        Task<RepositoryResponse<bool>> DeleteTrip(Trip Trip);
    }
}
