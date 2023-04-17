using Microsoft.AspNetCore.Mvc;
using mssqlProject.Services.IServices;
using mssqlProject.Models;
using mssqlProject.Services;
using Microsoft.AspNetCore.Cors;

namespace mssqlProject.WebApi.Controllers
{
    [ApiController]
    [EnableCors("poli1")]
    [Route("api/[controller]")]
    public class BudgetController : Controller
    {
        private readonly ITripService _TripService;
        private readonly IBudgetService   _BudgetService;

        public BudgetController(IBudgetService budgetService, ITripService tripService)
        {
            _BudgetService = budgetService;
            _TripService = tripService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<Budget>>> Get()
        {
            var response = await _BudgetService.GetBudgetsAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Budget>>> Get(int id)
        {
            var response = await _BudgetService.GetBudgetAsync(u => u.Id == id);
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
        public async Task<ActionResult<RepositoryResponse<Budget>>> Post([FromBody] BudgetDTO budget)
        {
            var trip = await _TripService.GetTripAsync(u => u.Id == budget.TripId);
            if (trip.Data == null)
            {
                return new RepositoryResponse<Budget> { Success = false, Message = "Trip don't exist" };
            }

            Budget newBudget = new Budget
            {
                TripId = budget.TripId,
                BankAccunt = budget.BankAccunt,
                ShareHoldersCount = budget.ShareHoldersCount,
                BudgetSize = budget.BudgetSize
            };

            var response = await _BudgetService.CreateBudget(newBudget);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Budget>>> Put([FromBody] Budget budget)
        {
            var response = await _BudgetService.UpdateBudget(budget);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _BudgetService.DeleteBudget(new Models.Budget() { Id = id });
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
