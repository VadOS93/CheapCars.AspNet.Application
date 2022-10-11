using CheapCars.Models.Joins;

using System.ComponentModel.DataAnnotations;

namespace CheapCars.Models;

public class Award
{
	[Key]
	public int Id { get; set; }

	[Required(ErrorMessage = "Logo is required")]
	public string Logo { get; set; }

	[Display(Name = "Award")]
	[Required(ErrorMessage = "Name is required")]
	public string Name { get; set; }

	[Display(Name = "Description")]
	[Required(ErrorMessage = "Description is required")]
	public string Description { get; set; }

	public List<Car_Award>? Cars_Awards { get; set; }
}