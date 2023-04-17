using mssqlProject.Models;

namespace mssqlProject.DataAccess.Repository.IRepository
{
    public interface IParticipantRepository : IRepository<Participant>
    {
        Task<RepositoryResponse<bool>> Update(Participant participant);
    }
}
