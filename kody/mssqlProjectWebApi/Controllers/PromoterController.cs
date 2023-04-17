using Microsoft.AspNetCore.Mvc;
using mssqlProject.Services.IServices;
using mssqlProject.Models;
using mssqlProject.Services;

namespace mssqlProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoterController : Controller
    {
        private readonly IPromoterService _PromoterService;
        private readonly ITripService _TripService;

        public PromoterController(IPromoterService promoterService, ITripService tripService)
        {
            _PromoterService = promoterService;
            _TripService = tripService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<Promoter>>> Get()
        {
            var response = await _PromoterService.GetPromotersAsync(null, "Trips");
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Promoter>>> Get(int id)
        {
            var response = await _PromoterService.GetPromoterAsync(u => u.Id == id, "Trips");
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
        public async Task<ActionResult<RepositoryResponse<Promoter>>> Post([FromBody] PromoterDTO promoter)
        {
            //var trip = await _TripService.GetTripAsync(u => u.Id == promoter.TripId);
            //if (trip.Data == null)
            //{
            //    promoter.TripId = -1;
            //}

            Promoter newPromoter = new Promoter
            {
                Name = promoter.Name,
                Surname = promoter.Surname,
                Email = promoter.Email,
                PhoneNumber = promoter.PhoneNumber,
                Trips = new List<Trip>()
            };

            var response = await _PromoterService.CreatePromoter(newPromoter);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Promoter>>> Put([FromBody] Promoter promoter)
        {
            var response = await _PromoterService.UpdatePromoter(promoter);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _PromoterService.DeletePromoter(new Models.Promoter() { Id = id });
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
