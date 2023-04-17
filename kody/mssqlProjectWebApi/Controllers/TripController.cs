using Microsoft.AspNetCore.Mvc;
using mssqlProject.Services.IServices;
using mssqlProject.Models;
using mssqlProject.Models.DTO;
using mssqlProject.Services;

namespace mssqlProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : Controller
    {
        private readonly ITripService     _TripService;
        private readonly IBudgetService   _BudgetService;
        private readonly IHotelService    _HotelService;
        private readonly IPromoterService _PromoterService;

        public TripController(ITripService tripService, IBudgetService budgetService, IHotelService hotelService, IPromoterService promoterService)
        {
            _TripService = tripService;
            _BudgetService = budgetService;
            _HotelService = hotelService;
            _PromoterService = promoterService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<Trip>>> Get()
        {
            var response = await _TripService.GetTripsAsync(null, "Hotel,Budget,Places,Participants,Groups");
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Trip>>> Get(int id)
        {
            var response = await _TripService.GetTripAsync(u => u.Id == id, "Hotel,Budget,Places,Participants,Groups");
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
        public async Task<ActionResult<RepositoryResponse<Trip>>> Post([FromBody] TripDTO trip)
        {
            var promoter = await _PromoterService.GetPromoterAsync(u => u.Id == trip.PromoterId);
            if (promoter.Data == null)
            {
                return new RepositoryResponse<Trip> { Success = false, Message = "Promoter don't exist" };
            }
            //var hotel = await _HotelService.GetHotelAsync(u => u.Id == trip.HotelId);
            //if (hotel.Data == null)
            //{
            //    return new RepositoryResponse<Trip> { Success = false, Message = "Promoter don't exist" };
            //}
            //var budget = await _BudgetService.GetBudgetAsync(u => u.Id == trip.BudgetId);
            //if (budget.Data == null)
            //{
            //    return new RepositoryResponse<Trip> { Success = false, Message = "Promoter don't exist" };
            //}

            Trip newTrip = new Trip
            {
                PromoterId = trip.PromoterId,
                Budget = null,
                Hotel = null,
                Participants = new List<Participant>(),
                Places = new List<Place>(),
                Groups = new List<Group>(),
                Date = trip.Date,
                Title = trip.Title,
                Description = trip.Description,
            };

            var response = await _TripService.CreateTrip(newTrip);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Trip>>> Put([FromBody] Trip trip)
        {
            var response = await _TripService.UpdateTrip(trip);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _TripService.DeleteTrip(new Models.Trip() { Id = id });
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
