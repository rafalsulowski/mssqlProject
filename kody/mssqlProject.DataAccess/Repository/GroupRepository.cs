using Microsoft.EntityFrameworkCore;
using mssqlProject.DataAccess.Data;
using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;

namespace mssqlProject.DataAccess.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(Group Group)
        {
            var GroupDb = await GetFirstOrDefault(u => u.Id == Group.Id);
            if (GroupDb == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Group with this Id was not found."
                };
            }
            _context.Groups.Attach(Group);
            _context.Entry(Group).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
