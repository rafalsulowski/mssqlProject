using Microsoft.EntityFrameworkCore;
using mssqlProject.DataAccess.Data;
using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;
using System.Linq.Expressions;
using System.Linq;

namespace mssqlProject.DataAccess.Repository
{
    public class PromoterRepository : Repository<Promoter>, IPromoterRepository
    {
        private ApplicationDbContext _context;
        public PromoterRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<RepositoryResponse<bool>> Update(Promoter Promoter)
        {
            var PromoterDB = await GetFirstOrDefault(u => u.Id == Promoter.Id);
            if (PromoterDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Promoter with this Id was not found."
                };
            }
            _context.Promoters.Attach(Promoter);
            _context.Entry(Promoter).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
