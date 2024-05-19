using Microsoft.EntityFrameworkCore;

namespace PizzaOrdering.Services;

public class PizzaService : IPizzaService {
	private readonly PizzaOrderContext _pizzaOrderContext;

	public PizzaService(PizzaOrderContext pizzaOrderContext) {
		_pizzaOrderContext = pizzaOrderContext;
	}

	public Task<List<Pizza>> GetAllPizzas() {
		return _pizzaOrderContext.Pizzas.ToListAsync();
	}
}