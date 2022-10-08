namespace CheapCars.Models.Joins;

public class Car_Award
{
	public int CarId { get; set; }
	public Car Car { get; set; }
	public int AwardId { get; set; }
	public Award Award { get; set; }
}