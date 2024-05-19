using Microsoft.EntityFrameworkCore;

public class PizzaOrderContext : DbContext {
	public PizzaOrderContext(DbContextOptions<PizzaOrderContext> options) : base(options) { }

	public DbSet<Pizza> Pizzas { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<DailyPizzaLimit> DailyPizzaLimits { get; set; }

	override protected void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.Entity<Pizza>().HasData(
						new Pizza { Id = 1, Name = "Margherita", Description = "Classic tomato and mozzarella cheese", Price = 8.99f, PizzaId = Guid.NewGuid() },
						new Pizza { Id = 2, Name = "Pepperoni", Description = "Pepperoni and cheese on tomato sauce", Price = 9.99f, PizzaId = Guid.NewGuid() },
						new Pizza { Id = 3, Name = "Vegetarian", Description = "Mixed vegetables and cheese on tomato sauce", Price = 9.99f, PizzaId = Guid.NewGuid() }
				);
	}
}
