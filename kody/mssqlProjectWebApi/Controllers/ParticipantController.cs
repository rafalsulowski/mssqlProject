using Microsoft.AspNetCore.Mvc;
using mssqlProject.Services.IServices;
using mssqlProject.Models;
using mssqlProject.Services;

namespace mssqlProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : Controller
    {
        private readonly IParticipantService _ParticipantService;
        private readonly IGroupService _GroupService;
        private readonly ITripService _TripService;

        public ParticipantController(IParticipantService participantService, IGroupService groupService, ITripService tripService)
        {
            _ParticipantService = participantService;
            _GroupService = groupService;
            _TripService = tripService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<Participant>>> Get()
        {
            var response = await _ParticipantService.GetParticipantsAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Participant>>> Get(int id)
        {
            var response = await _ParticipantService.GetParticipantAsync(u => u.Id == id);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Data);
            }
        }

        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<Participant>>> Post([FromBody] ParticipantDTO participant)
        {
            var trip = await _TripService.GetTripAsync(u => u.Id == participant.TripId);
            if (trip.Data == null)
            {
                return new RepositoryResponse<Participant> { Success = false, Message = "Trip don't exist" };
            }
            var group = await _GroupService.GetGroupAsync(u => u.Id == participant.GroupId);
            if (group.Data == null)
            {
                return new RepositoryResponse<Participant> { Success = false, Message = "Group don't exist" };
            }

            Participant newParticipant = new Participant
            {
                TripId = participant.TripId,
                GroupId = participant.GroupId,
                PhoneNumber = participant.PhoneNumber,
                PasswordHash = participant.PasswordHash,
                Email = participant.Email
            };

            var response = await _ParticipantService.CreateParticipant(newParticipant);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Participant>>> Put([FromBody] Participant participant)
        {
            var response = await _ParticipantService.UpdateParticipant(participant);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _ParticipantService.DeleteParticipant(new Models.Participant() { Id = id });
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Data);
            }
        }

    }
}
