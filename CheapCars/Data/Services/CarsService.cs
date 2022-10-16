using CheapCars.Data.ViewModels;
using CheapCars.Models;

using Microsoft.EntityFrameworkCore;

namespace CheapCars.Data.Services;

internal sealed class CarsService : ICarsService
{
	private readonly CarDbContext _context;

	public CarsService(CarDbContext context)
	{
		_context = context;
	}

	public Task AddNewCar(NewCarVM data)
	{
		throw new NotImplementedException();
	}

	public async Task<Car> GetCarById(int id)
	{
		var cars = await _context.Cars.Where(x => x.Id == id)
			.Include(x => x.Cars_SpecialAbilities).ThenInclude(y => y.SpecialAbility)
			.Include(x => x.SellPlace)
			.Include(x => x.Cars_Awards).ThenInclude(y => y.Award).FirstOrDefaultAsync();

		return cars;
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