using Microsoft.EntityFrameworkCore;
using mssqlProject.DataAccess.Data;
using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;

namespace mssqlProject.DataAccess.Repository
{
    public class BudgetRepository : Repository<Budget>, IBudgetRepository
    {
        private ApplicationDbContext _context;
        public BudgetRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(Budget Budget)
        {
            var BudgetDb = await GetFirstOrDefault(u => u.Id == Budget.Id);
            if (BudgetDb == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Budget with this Id was not found."
                };
            }
            _context.Budgets.Attach(Budget);
            _context.Entry(Budget).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
