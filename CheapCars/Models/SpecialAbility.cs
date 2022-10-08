using CheapCars.Models.Joins;

using System.ComponentModel.DataAnnotations;

namespace CheapCars.Models;

public class SpecialAbility
{
	[Key]
	public int Id { get; set; }
	public string SpecialAbilityURLPicture { get; set; }

	[Display(Name = "Special Ability")]
	public string Name { get; set; }

	[Display(Name = "Description")]
	public string Description { get; set; }
	public List<Car_SpecialAbility> Cars_SpecialAbilities { get; set; }
}