using Microsoft.EntityFrameworkCore;
using mssqlProject.DataAccess.Data;
using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;
using mssqlProject.Models.DTO;

namespace mssqlProject.DataAccess.Repository
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        private ApplicationDbContext _context;
        public TripRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(Trip trip)
        {
            var tripDB = await GetFirstOrDefault(u => u.Id == trip.Id);
            if (tripDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Trip with this Id was not found."
                };
            }
            _context.Trips.Attach(trip);
            _context.Entry(trip).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
