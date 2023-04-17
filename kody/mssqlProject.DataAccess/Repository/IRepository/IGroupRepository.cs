using mssqlProject.Models;

namespace mssqlProject.DataAccess.Repository.IRepository
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<RepositoryResponse<bool>> Update(Group group);
    }
}
