using mssqlProject.Models;
using mssqlProject.Models.DTO;

namespace mssqlProject.DataAccess.Repository.IRepository
{
    public interface ITripRepository : IRepository<Trip>
    {
        Task<RepositoryResponse<bool>> Update(Trip trip);
    }
}
