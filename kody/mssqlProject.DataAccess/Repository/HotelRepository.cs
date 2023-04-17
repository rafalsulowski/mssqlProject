using Microsoft.EntityFrameworkCore;
using mssqlProject.DataAccess.Data;
using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;

namespace mssqlProject.DataAccess.Repository
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        private ApplicationDbContext _context;
        public HotelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(Hotel Hotel)
        {
            var HotelDb = await GetFirstOrDefault(u => u.Id == Hotel.Id);
            if (HotelDb == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Hotel with this Id was not found."
                };
            }
            _context.Hotels.Attach(Hotel);
            _context.Entry(Hotel).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
