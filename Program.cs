using Microsoft.EntityFrameworkCore;
using PizzaOrdering.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5000");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PizzaOrderContext>(options => {
	options.UseSqlite("Data Source=mydatabase.db");
});

builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ILimitService, LimitService>();

builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
