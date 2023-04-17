using mssqlProject.Models;

namespace mssqlProject.DataAccess.Repository.IRepository
{
    public interface IBudgetRepository : IRepository<Budget>
    {
        Task<RepositoryResponse<bool>> Update(Budget Budget);
    }
}
