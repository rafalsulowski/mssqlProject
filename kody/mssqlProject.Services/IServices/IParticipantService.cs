using System.Linq.Expressions;
using mssqlProject.Models;

namespace mssqlProject.Services.IServices
{
    public interface IParticipantService
    {
        Task<RepositoryResponse<List<Participant>>> GetParticipantsAsync(Expression<Func<Participant, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Participant>> GetParticipantAsync(Expression<Func<Participant, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateParticipant(Participant Participant);
        Task<RepositoryResponse<bool>> UpdateParticipant(Participant Participant);
        Task<RepositoryResponse<bool>> DeleteParticipant(Participant Participant);
    }
}
