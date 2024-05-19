using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrdering.Services;

namespace PizzaOrdering.Controller;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase {
	private readonly IPizzaService _pizzaService;

	public PizzaController(IPizzaService pizzaService) {
		_pizzaService = pizzaService;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas() {
		return await _pizzaService.GetAllPizzas();
	}
}