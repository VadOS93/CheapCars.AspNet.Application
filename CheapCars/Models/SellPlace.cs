using System.ComponentModel.DataAnnotations;

namespace CheapCars.Models;

public class SellPlace
{
	[Key]
	public int Id { get; set; }
	public string SellPlaceURLPicture { get; set; }

	[Display(Name = "Sell Place")]
	public string Name { get; set; }

	[Display(Name = "Description")]
	public string Description { get; set; }
	public List<Car>? Cars { get; set; }
}