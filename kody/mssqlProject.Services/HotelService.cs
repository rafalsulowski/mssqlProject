using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;
using mssqlProject.Services.IServices;
using System.Linq.Expressions;

namespace mssqlProject.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _HotelRepository;
        public HotelService(IHotelRepository HotelRepository)
        {
            _HotelRepository = HotelRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateHotel(Hotel Hotel)
        {
            _HotelRepository.Add(Hotel);
            var response = await _HotelRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteHotel(Hotel Hotel)
        {
            _HotelRepository.Remove(Hotel);
            var response = await _HotelRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Hotel>> GetHotelAsync(Expression<Func<Hotel, bool>> filter, string? includeProperties = null)
        {
            var response = await _HotelRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Hotel>>> GetHotelsAsync(Expression<Func<Hotel, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _HotelRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateHotel(Hotel Hotel)
        {
            var response = await _HotelRepository.Update(Hotel);
            if(response.Success==false)
            {
                return response;
            }
            response = await _HotelRepository.SaveChangesAsync();
            return response;
        }
    }
}
