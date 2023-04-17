using mssqlProject.Models;

namespace mssqlProject.DataAccess.Repository.IRepository
{
    public interface IPromoterRepository : IRepository<Promoter>
    {
        Task<RepositoryResponse<bool>> Update(Promoter promoter);
    }
}
