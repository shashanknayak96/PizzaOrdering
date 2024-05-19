public interface ILimitService {
	public Task<List<DailyPizzaLimit>> GetLimits();
	public Task<bool> setPizzaLimit(Guid pizzaId, int limit);
}