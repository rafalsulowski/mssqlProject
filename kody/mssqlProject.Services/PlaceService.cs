using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;
using mssqlProject.Services.IServices;
using System.Linq.Expressions;

namespace mssqlProject.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _PlaceRepository;
        public PlaceService(IPlaceRepository PlaceRepository)
        {
            _PlaceRepository = PlaceRepository;
        }

        public async Task<RepositoryResponse<bool>> CreatePlace(Place Place)
        {
            _PlaceRepository.Add(Place);
            var response = await _PlaceRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeletePlace(Place Place)
        {
            _PlaceRepository.Remove(Place);
            var response = await _PlaceRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Place>> GetPlaceAsync(Expression<Func<Place, bool>> filter, string? includeProperties = null)
        {
            var response = await _PlaceRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Place>>> GetPlacesAsync(Expression<Func<Place, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _PlaceRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdatePlace(Place Place)
        {
            var response = await _PlaceRepository.Update(Place);
            if(response.Success==false)
            {
                return response;
            }
            response = await _PlaceRepository.SaveChangesAsync();
            return response;
        }
    }
}
