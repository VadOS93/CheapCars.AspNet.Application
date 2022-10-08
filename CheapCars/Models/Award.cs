using CheapCars.Models.Joins;

using System.ComponentModel.DataAnnotations;

namespace CheapCars.Models;

public class Award
{
	[Key]
	public int Id { get; set; }
	public string Logo { get; set; }

	[Display(Name = "Award")]
	public string Name { get; set; }

	[Display(Name = "Description")]
	public string Description { get; set; }
	public List<Car_Award> Cars_Awards { get; set; }
}