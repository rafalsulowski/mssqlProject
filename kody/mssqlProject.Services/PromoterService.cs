using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;
using mssqlProject.Services.IServices;
using System.Linq.Expressions;

namespace mssqlProject.Services
{
    public class PromoterService : IPromoterService
    {
        private readonly IPromoterRepository _PromoterRepository;
        public PromoterService(IPromoterRepository PromoterRepository)
        {
            _PromoterRepository = PromoterRepository;
        }

        public async Task<RepositoryResponse<bool>> CreatePromoter(Promoter Promoter)
        {
            _PromoterRepository.Add(Promoter);
            var response = await _PromoterRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeletePromoter(Promoter Promoter)
        {
            _PromoterRepository.Remove(Promoter);
            var response = await _PromoterRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Promoter>> GetPromoterAsync(Expression<Func<Promoter, bool>> filter, string? includeProperties = null)
        {
            var response = await _PromoterRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Promoter>>> GetPromotersAsync(Expression<Func<Promoter, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _PromoterRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdatePromoter(Promoter Promoter)
        {
            var response = await _PromoterRepository.Update(Promoter);
            if(response.Success==false)
            {
                return response;
            }
            response = await _PromoterRepository.SaveChangesAsync();
            return response;
        }
    }
}
