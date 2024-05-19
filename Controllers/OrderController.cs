using Microsoft.AspNetCore.Mvc;
using PizzaOrdering.Services;

namespace PizzaOrdering.Controller;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase {
	private readonly IOrderService _orderService;

	public OrderController(IOrderService orderService) {
		_orderService = orderService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllOrders() {
		var orders = await _orderService.GetAllOrders();

		return StatusCode(StatusCodes.Status200OK, orders);
	}

	[HttpGet("today")]
	public async Task<IActionResult> GetAllOrdersForToday() {
		var orders = await _orderService.GetAllOrdersForToday();

		return StatusCode(StatusCodes.Status200OK, orders);
	}

	[HttpPost("{pizzaId}/{quantity}")]
	public async Task<ActionResult<IEnumerable<Pizza>>> OrderPizza(Guid pizzaId, int quantity) {
		try {
			var order = await _orderService.CreateOrder(pizzaId, quantity);

			return StatusCode(StatusCodes.Status200OK, order);
		} catch (Exception ex) {
			return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
		}
	}
}