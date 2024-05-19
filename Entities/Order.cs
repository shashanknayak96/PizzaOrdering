using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order {

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public Guid OrderId { get; set; }
	public DateTime OrderDate { get; set; }
	public string CustomerName { get; set; }
	public int Quantity { get; set; }
	public Guid PizzaId { get; set; }

	public Pizza Pizzas { get; set; }
}