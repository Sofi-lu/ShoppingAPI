using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.DAL.Entities;
using ShoppingAPI.Domain.Interfaces;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet("GetByCountryId/{countryId}")]
        public async Task<ActionResult<IEnumerable<State>>> GetStatesByCountryIdAsync(Guid countryId)
        {
            var states = await _stateService.GetStatesByCountryIdAsync(countryId);
            if (states == null || !states.Any()) return NotFound();
            return Ok(states);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<ActionResult<State>> GetStateByNameAsync(string name)
        {
            var state = await _stateService.GetStateByNameAsync(name);
            if (state == null) return NotFound();
            return Ok(state);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<State>> CreateStateAsync(State state)
        {
            try
            {
                var created = await _stateService.CreateStateAsync(state);
                return Ok(created);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<State>> EditStateAsync(State state)
        {
            try
            {
                var updated = await _stateService.EditStateAsync(state);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<State>> DeleteStateAsync(Guid id)
        {
            var deleted = await _stateService.DeleteStateAsync(id);
            if (deleted == null) return NotFound();
            return Ok(deleted);
        }
    }
}
