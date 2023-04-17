using mssqlProject.Models;

namespace mssqlProject.DataAccess.Repository.IRepository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<RepositoryResponse<bool>> Update(Comment comment);
    }
}
