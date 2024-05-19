namespace PizzaOrdering.Services;

public interface IOrderService {
	Task<List<Order>> GetAllOrders();
	Task<List<Order>> GetAllOrdersForToday();
	Task<Guid> CreateOrder(Guid pizzaId, int quantity);
}