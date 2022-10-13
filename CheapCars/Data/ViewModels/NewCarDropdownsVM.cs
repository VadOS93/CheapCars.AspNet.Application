using CheapCars.Models;

namespace CheapCars.Data.ViewModels;

public class NewCarDropdownsVM
{
	public NewCarDropdownsVM()
	{
		Awards = new List<Award>();
		SellPlaces = new List<SellPlace>();
		SpecialAbilities = new List<SpecialAbility>();
	}

	public List<Award> Awards { get; set; }
	public List<SellPlace> SellPlaces { get; set; }
	public List<SpecialAbility> SpecialAbilities { get; set; }
}