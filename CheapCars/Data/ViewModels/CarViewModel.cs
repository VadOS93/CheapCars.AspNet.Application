using CheapCars.Models;

namespace CheapCars.Data.ViewModels;

public class CarViewModel
{
	public IEnumerable<Car> Cars { get; set; }
	public int CarPerPage { get; set; }
	public int CurrentPage { get; set; }

	public int PageCount()
	{
		return Convert.ToInt32(Math.Ceiling(Cars.Count() / (double)CarPerPage));
	}
	public IEnumerable<Car> PaginatedCars()
	{
		int start = (CurrentPage - 1) * CarPerPage;
		return Cars.Skip(start).Take(CarPerPage);
	}
}