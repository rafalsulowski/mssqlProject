using Microsoft.EntityFrameworkCore;
using mssqlProject.DataAccess.Data;
using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;

namespace mssqlProject.DataAccess.Repository
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        private ApplicationDbContext _context;
        public PlaceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(Place place)
        {
            var placeDb = await GetFirstOrDefault(u => u.Id == place.Id);
            if (placeDb == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Place with this Id was not found."
                };
            }
            _context.Places.Attach(place);
            _context.Entry(place).State = EntityState.Modified;
            _context.SaveChanges();
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
