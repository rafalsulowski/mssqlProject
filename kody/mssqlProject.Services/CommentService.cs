using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;
using mssqlProject.Services.IServices;
using System.Linq.Expressions;

namespace mssqlProject.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _CommentRepository;
        public CommentService(ICommentRepository CommentRepository)
        {
            _CommentRepository = CommentRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateComment(Comment Comment)
        {
            _CommentRepository.Add(Comment);
            var response = await _CommentRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteComment(Comment Comment)
        {
            _CommentRepository.Remove(Comment);
            var response = await _CommentRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Comment>> GetCommentAsync(Expression<Func<Comment, bool>> filter, string? includeProperties = null)
        {
            var response = await _CommentRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Comment>>> GetCommentsAsync(Expression<Func<Comment, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _CommentRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateComment(Comment Comment)
        {
            var response = await _CommentRepository.Update(Comment);
            if(response.Success==false)
            {
                return response;
            }
            response = await _CommentRepository.SaveChangesAsync();
            return response;
        }
    }
}
