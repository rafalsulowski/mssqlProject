using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;
using mssqlProject.Services.IServices;
using System.Linq.Expressions;

namespace mssqlProject.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _ParticipantRepository;
        public ParticipantService(IParticipantRepository ParticipantRepository)
        {
            _ParticipantRepository = ParticipantRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateParticipant(Participant Participant)
        {
            _ParticipantRepository.Add(Participant);
            var response = await _ParticipantRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteParticipant(Participant Participant)
        {
            _ParticipantRepository.Remove(Participant);
            var response = await _ParticipantRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Participant>> GetParticipantAsync(Expression<Func<Participant, bool>> filter, string? includeProperties = null)
        {
            var response = await _ParticipantRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Participant>>> GetParticipantsAsync(Expression<Func<Participant, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _ParticipantRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateParticipant(Participant Participant)
        {
            var response = await _ParticipantRepository.Update(Participant);
            if(response.Success==false)
            {
                return response;
            }
            response = await _ParticipantRepository.SaveChangesAsync();
            return response;
        }
    }
}
