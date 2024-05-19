using System.Net;
using Microsoft.AspNetCore.Mvc;
using PizzaOrdering.Services;

namespace PizzaOrdering.Controller;

[ApiController]
[Route("api/[controller]")]
public class LimitController : ControllerBase {
	private readonly ILimitService _limitService;

	public LimitController(ILimitService limitService) {
		_limitService = limitService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllLimits() {
		var dailyLimits = await _limitService.GetLimits();

		return StatusCode(StatusCodes.Status200OK, dailyLimits);
	}

	[HttpPost("{pizzaId}/{limit}")]
	public async Task<ActionResult<IEnumerable<Pizza>>> LimitPizzaForToday(Guid pizzaId, int limit) {
		var order = await _limitService.setPizzaLimit(pizzaId, limit);

		if (order) {
			return Ok("Daily limit set successfully!");
		} else {
			return StatusCode(StatusCodes.Status500InternalServerError, "Daily limit cannot be set. Please try again later.");
		}
	}
}