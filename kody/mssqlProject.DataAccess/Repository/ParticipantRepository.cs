using Microsoft.EntityFrameworkCore;
using mssqlProject.DataAccess.Data;
using mssqlProject.Models;
using mssqlProject.DataAccess.Repository.IRepository;

namespace mssqlProject.DataAccess.Repository
{
    public class ParticipantRepository : Repository<Participant>, IParticipantRepository
    {
        private ApplicationDbContext _context;
        public ParticipantRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(Participant Participant)
        {
            var ParticipantDb = await GetFirstOrDefault(u => u.Id == Participant.Id);
            if (ParticipantDb == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Participant with this Id was not found."
                };
            }
            _context.Participants.Attach(Participant);
            _context.Entry(Participant).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
