using mssqlProject.Models;

namespace mssqlProject.DataAccess.Repository.IRepository
{
    public interface IPlaceRepository : IRepository<Place>
    {
        Task<RepositoryResponse<bool>> Update(Place place);
    }
}
