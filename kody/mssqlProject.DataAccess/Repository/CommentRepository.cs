using Microsoft.EntityFrameworkCore;
using mssqlProject.DataAccess.Data;
using mssqlProject.DataAccess.Repository.IRepository;
using mssqlProject.Models;

namespace mssqlProject.DataAccess.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(Comment comment)
        {
            var commentDb = await GetFirstOrDefault(u => u.Id == comment.Id);
            if (commentDb == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Comment with this Id was not found."
                };
            }
            _context.Comments.Attach(comment);
            _context.Entry(comment).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
