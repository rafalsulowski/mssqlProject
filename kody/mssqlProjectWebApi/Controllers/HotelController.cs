using Microsoft.AspNetCore.Mvc;
using mssqlProject.Services.IServices;
using mssqlProject.Models;
using mssqlProject.Services;

namespace mssqlProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        private readonly IHotelService _HotelService;
        private readonly ITripService _TripService;

        public HotelController(IHotelService hotelService, ITripService tripService)
        {
            _HotelService = hotelService;
            _TripService = tripService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<Hotel>>> Get()
        {
            var response = await _HotelService.GetHotelsAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Hotel>>> Get(int id)
        {
            var response = await _HotelService.GetHotelAsync(u => u.Id == id);
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
        public async Task<ActionResult<RepositoryResponse<Hotel>>> Post([FromBody] HotelDTO hotel)
        {
            var trip = await _TripService.GetTripAsync(u => u.Id == hotel.TripId);
            if (trip.Data == null)
            {
                return new RepositoryResponse<Hotel> { Success = false, Message = "Trip don't exist" };
            }

            Hotel newHotel = new Hotel
            {
                TripId = hotel.TripId,
                Designation = hotel.Designation,
                Location = hotel.Location,
                Price = hotel.Price
            };

            var response = await _HotelService.CreateHotel(newHotel);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Hotel>>> Put([FromBody] Hotel hotel)
        {
            var response = await _HotelService.UpdateHotel(hotel);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _HotelService.DeleteHotel(new Models.Hotel() { Id = id });
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
