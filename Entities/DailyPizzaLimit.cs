using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DailyPizzaLimit {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public Guid LimitId { get; set; }
	public DateTime Date { get; set; }
	public int Limit { get; set; }
	public int SoldCount { get; set; }
	public Guid PizzaId { get; set; }

	public virtual Pizza Pizza { get; set; }
}