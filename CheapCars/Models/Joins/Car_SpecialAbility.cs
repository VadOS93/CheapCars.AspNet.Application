namespace CheapCars.Models.Joins;

public class Car_SpecialAbility
{
	public int CarId { get; set; }
	public Car Car { get; set; }
	public int SpecialAbilityId { get; set; }
	public SpecialAbility SpecialAbility { get; set; }
}