using CheapCars.Data.ViewModels;
using CheapCars.Models;

namespace CheapCars.Data.Services;

internal sealed class CarsService : ICarsService
{
	public Task AddNewCar(NewCarVM data)
	{
		throw new NotImplementedException();
	}

	public Task<Car> GetCarById(int id)
	{
		throw new NotImplementedException();
	}

	public Task<NewCarDropdownsVM> GetNewCarDropdownsValues()
	{
		throw new NotImplementedException();
	}

	public Task UpdateCar(NewCarVM data)
	{
		throw new NotImplementedException();
	}
}