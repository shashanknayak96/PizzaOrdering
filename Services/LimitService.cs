using Microsoft.EntityFrameworkCore;

namespace PizzaOrdering.Services;

public class LimitService : ILimitService {
	private readonly PizzaOrderContext _orderContext;

	public LimitService(PizzaOrderContext orderContext) {
		_orderContext = orderContext;
	}

	public async Task<List<DailyPizzaLimit>> GetLimits() {
		try {
			return await _orderContext.DailyPizzaLimits.ToListAsync();
		} catch (Exception ex) {
			return null;
		}
	}

	public async Task<bool> setPizzaLimit(Guid pizzaId, int limit) {
		try {
			var today = DateTime.UtcNow.Date;

			var dailyLimit = await _orderContext.DailyPizzaLimits.FirstOrDefaultAsync(d => d.Date == today && d.PizzaId == pizzaId);

			if (dailyLimit == null) {
				dailyLimit = new DailyPizzaLimit { PizzaId = pizzaId, Date = today, Limit = limit, SoldCount = 0, LimitId = Guid.NewGuid() };
				_orderContext.DailyPizzaLimits.Add(dailyLimit);
			} else {
				dailyLimit.Limit = limit;
			}

			await _orderContext.SaveChangesAsync();

			return true;
		} catch (Exception ex) {
			return false;
		}
	}
}