using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;
using mssqlProject.Services.IServices;
using System.Linq.Expressions;
using mssqlProject.Models.DTO;

namespace mssqlProject.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _TripRepository;
        public TripService(ITripRepository TripRepository)
        {
            _TripRepository = TripRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateTrip(Trip Trip)
        {
            _TripRepository.Add(Trip);
            var response = await _TripRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteTrip(Trip Trip)
        {
            _TripRepository.Remove(Trip);
            var response = await _TripRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Trip>> GetTripAsync(Expression<Func<Trip, bool>> filter, string? includeProperties = null)
        {
            var response = await _TripRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Trip>>> GetTripsAsync(Expression<Func<Trip, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _TripRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateTrip(Trip Trip)
        {
            var response = await _TripRepository.Update(Trip);
            if(response.Success==false)
            {
                return response;
            }
            response = await _TripRepository.SaveChangesAsync();
            return response;
        }
    }
}
