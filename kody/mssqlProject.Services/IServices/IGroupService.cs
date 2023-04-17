using System.Linq.Expressions;
using mssqlProject.Models;

namespace mssqlProject.Services.IServices
{
    public interface IGroupService
    {
        Task<RepositoryResponse<List<Group>>> GetGroupsAsync(Expression<Func<Group, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Group>> GetGroupAsync(Expression<Func<Group, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateGroup(Group Group);
        Task<RepositoryResponse<bool>> UpdateGroup(Group Group);
        Task<RepositoryResponse<bool>> DeleteGroup(Group Group);
    }
}
