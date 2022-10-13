using System.ComponentModel.DataAnnotations;

namespace CheapCars.Models;

public class BusketItem
{
	[Key]
	public int Id { get; set; }

	public Car Car { get; set; }
	public int Amount { get; set; }


	public string BusketId { get; set; }
}
