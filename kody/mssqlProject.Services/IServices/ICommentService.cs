using System.Linq.Expressions;
using mssqlProject.Models;

namespace mssqlProject.Services.IServices
{
    public interface ICommentService
    {
        Task<RepositoryResponse<List<Comment>>> GetCommentsAsync(Expression<Func<Comment, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Comment>> GetCommentAsync(Expression<Func<Comment, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateComment(Comment Comment);
        Task<RepositoryResponse<bool>> UpdateComment(Comment Comment);
        Task<RepositoryResponse<bool>> DeleteComment(Comment Comment);
    }
}
