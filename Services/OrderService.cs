using Microsoft.EntityFrameworkCore;

namespace PizzaOrdering.Services;

public class OrderService : IOrderService {
	private readonly PizzaOrderContext _pizzaOrderContext;

	public OrderService(PizzaOrderContext pizzaOrderContext) {
		_pizzaOrderContext = pizzaOrderContext;
	}

	public async Task<Guid> CreateOrder(Guid pizzaId, int quantity) {

		var today = DateTime.UtcNow.Date;

		using (var transaction = await _pizzaOrderContext.Database.BeginTransactionAsync()) {
			var dailyLimit = await _pizzaOrderContext.DailyPizzaLimits.FirstOrDefaultAsync(x => x.Date == today);

			if (dailyLimit == null) {
				dailyLimit = new DailyPizzaLimit { Date = today, Limit = 10, SoldCount = 0 };
				_pizzaOrderContext.DailyPizzaLimits.Add(dailyLimit);
				await _pizzaOrderContext.SaveChangesAsync();
			}

			if (dailyLimit.SoldCount + quantity > dailyLimit.Limit) {
				throw new Exception("Pizza limit reached for today.");
			}

			var orderId = Guid.NewGuid();
			var order = new Order {
				OrderId = orderId,
				CustomerName = "Admin",
				PizzaId = pizzaId,
				OrderDate = today,
				Quantity = quantity
			};
			_pizzaOrderContext.Orders.Add(order);

			dailyLimit.SoldCount += quantity;

			try {
				await _pizzaOrderContext.SaveChangesAsync();
				await transaction.CommitAsync();

				return orderId;
			} catch (DbUpdateConcurrencyException) {
				throw new Exception("A concurrency error occurred. Please try again.");
			}
		}
	}

	public async Task<List<Order>> GetAllOrders() {
		return await _pizzaOrderContext.Orders.ToListAsync();
	}

	public async Task<List<Order>> GetAllOrdersForToday() {
		var today = DateTime.UtcNow.Date;

		return await _pizzaOrderContext.Orders.Where(x => x.OrderDate == today).ToListAsync();
	}
}