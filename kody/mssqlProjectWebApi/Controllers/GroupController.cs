using Microsoft.AspNetCore.Mvc;
using mssqlProject.Services.IServices;
using mssqlProject.Models;
using mssqlProject.Services;

namespace mssqlProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroupService _GroupService;
        private readonly ITripService _TripService;


        public GroupController(IGroupService groupService, ITripService tripService)
        {
            _GroupService = groupService;
            _TripService = tripService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<Group>>> Get()
        {
            var response = await _GroupService.GetGroupsAsync(null,"Participants");
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Group>>> Get(int id)
        {
            var response = await _GroupService.GetGroupAsync(u => u.Id == id, "Participants");
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
        public async Task<ActionResult<RepositoryResponse<Group>>> Post([FromBody] GroupDTO group)
        {
            var trip = await _TripService.GetTripAsync(u => u.Id == group.TripId);
            if (trip.Data == null)
            {
                return new RepositoryResponse<Group> { Success = false, Message = "Trip don't exist" };
            }

            Group newGroup = new Group
            {
                TripId = group.TripId,
                Name = group.Name,
                MaxSize = group.MaxSize,
                Participants = new List<Participant>()
            };

            var response = await _GroupService.CreateGroup(newGroup);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Group>>> Put([FromBody] Group group)
        {
            var response = await _GroupService.UpdateGroup(group);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _GroupService.DeleteGroup(new Models.Group() { Id = id });
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
