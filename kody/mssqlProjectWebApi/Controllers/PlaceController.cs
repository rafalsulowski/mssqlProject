using Microsoft.AspNetCore.Mvc;
using mssqlProject.Services.IServices;
using mssqlProject.Models;
using mssqlProject.Services;

namespace mssqlProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : Controller
    {
        private readonly IPlaceService _PlaceService;
        private readonly ITripService _TripService;

        public PlaceController(IPlaceService placeService, ITripService tripService)
        {
            _PlaceService = placeService;
            _TripService = tripService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<Place>>> Get()
        {
            var response = await _PlaceService.GetPlacesAsync(null, "Comments");
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Place>>> Get(int id)
        {
            var response = await _PlaceService.GetPlaceAsync(u => u.Id == id, "Comments");
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
        public async Task<ActionResult<RepositoryResponse<Place>>> Post([FromBody] PlaceDTO place)
        {
            var trip = await _TripService.GetTripAsync(u => u.Id == place.TripId);
            if (trip.Data == null)
            {
                return new RepositoryResponse<Place> { Success = false, Message = "Trip don't exist" };
            }

            Place newPlace = new Place
            {
                TripId = place.TripId,
                Description = place.Description,
                Name = place.Name,
                Location = place.Location,
                Comments = new List<Comment>()
            };

            var response = await _PlaceService.CreatePlace(newPlace);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Place>>> Put([FromBody] Place place)
        {
            var response = await _PlaceService.UpdatePlace(place);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _PlaceService.DeletePlace(new Models.Place() { Id = id });
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
