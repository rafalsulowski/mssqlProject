using mssqlProject.Models;

namespace mssqlProject.DataAccess.Repository.IRepository
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<RepositoryResponse<bool>> Update(Hotel hotel);
    }
}
