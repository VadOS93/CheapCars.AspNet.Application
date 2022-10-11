using CheapCars.Data.Enums;
using CheapCars.Models.Joins;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheapCars.Models;

public class Car
{
	[Key]
	public int Id { get; set; }
	public string Name { get; set; }
	public string CarInfo { get; set; }
	public double Price { get; set; }
	public string ImageURL { get; set; }
	public DateTime StartSalesDate { get; set; }
	public DateTime EndSalesDate { get; set; }
	public CarType CarType { get; set; }
	public List<Car_Award>? Cars_Awards { get; set; }
	public List<Car_SpecialAbility>? Cars_SpecialAbilities { get; set; }
	public int SellPlaceId { get; set; }
	[ForeignKey("SellPlaceId")]
	public SellPlace SellPlace { get; set; }
}