namespace PizzaOrdering.Services;

public interface IPizzaService {
	public Task<List<Pizza>> GetAllPizzas();
}