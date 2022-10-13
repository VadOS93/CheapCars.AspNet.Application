using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CheapCars.Models;

public class OrderItem
{
	[Key]
	public int Id { get; set; }

	public int Amount { get; set; }
	public double Price { get; set; }

	public int CarId { get; set; }

	[ForeignKey("CarId")]
	public Car Car { get; set; }

	public int OrderId { get; set; }

	[ForeignKey("OrderId")]
	public Order Order { get; set; }
}