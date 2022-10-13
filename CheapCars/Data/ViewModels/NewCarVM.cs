using CheapCars.Data.Enums;

using System.ComponentModel.DataAnnotations;

namespace CheapCars.Data.ViewModels;

public class NewCarVM
{
	public int Id { get; set; }

	[Display(Name = "Car name")]
	[Required(ErrorMessage = "Name is required")]
	public string Name { get; set; }

	[Display(Name = "Car info")]
	[Required(ErrorMessage = "Information is required")]
	public string CarInfo { get; set; }

	[Display(Name = "Price in $")]
	[Required(ErrorMessage = "Price is required")]
	public double Price { get; set; }

	[Display(Name = "Car poster URL")]
	[Required(ErrorMessage = "Car poster URL is required")]
	public string ImageURL { get; set; }

	[Display(Name = "Car start sales date")]
	[Required(ErrorMessage = "Start sales date is required")]
	public DateTime StartSalesDate { get; set; }

	[Display(Name = "Car end sales date")]
	[Required(ErrorMessage = "End sales date is required")]
	public DateTime EndSalesDate { get; set; }

	[Display(Name = "Select a type")]
	[Required(ErrorMessage = "Car type is required")]
	public CarType CarType { get; set; }

	//Relationships
	[Display(Name = "Select award(s)")]
	[Required(ErrorMessage = "Car award(s) is required")]
	public List<int> AwardIds { get; set; }

	[Display(Name = "Select a sell place")]
	[Required(ErrorMessage = "Car sell place is required")]
	public int SellPlaceId { get; set; }

	[Display(Name = "Select special ability(s)")]
	[Required(ErrorMessage = "Car special ability(s) is required")]
	public List<int> SpecialAbilityIds { get; set; }
}
