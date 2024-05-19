using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pizza {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public Guid PizzaId { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public float Price { get; set; }

	public List<Order> Orders { get; set; }
}