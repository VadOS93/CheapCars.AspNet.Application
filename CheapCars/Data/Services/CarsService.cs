using CheapCars.Data.ViewModels;
using CheapCars.Models;
using CheapCars.Models.Joins;

using Microsoft.EntityFrameworkCore;

namespace CheapCars.Data.Services;

internal sealed class CarsService : ICarsService
{
	private readonly CarDbContext _context;

	public CarsService(CarDbContext context)
	{
		_context = context;
	}

	public async Task AddNewCar(NewCarVM data)
	{
		var newCar = new Car()
		{
			Name = data.Name,
			CarInfo = data.CarInfo,
			Price = data.Price,
			ImageURL = data.ImageURL,
			StartSalesDate = data.StartSalesDate,
			EndSalesDate = data.EndSalesDate,
			CarType = data.CarType,
			SellPlaceId = data.SellPlaceId
		};
		await _context.Cars.AddAsync(newCar);
		await _context.SaveChangesAsync();

		//Add Car Awards
		foreach (var awardId in data.AwardIds)
		{
			var newCarAward = new Car_Award()
			{
				CarId = newCar.Id,
				AwardId = awardId
			};
			await _context.Cars_Awards.AddAsync(newCarAward);
		}

		//Add Car Special Abilities
		foreach (var specialAbilityId in data.SpecialAbilityIds)
		{
			var newCarSpecialAbility = new Car_SpecialAbility()
			{
				CarId = newCar.Id,
				SpecialAbilityId = specialAbilityId
			};
			await _context.Cars_SpecialAbilities.AddAsync(newCarSpecialAbility);
		}
		await _context.SaveChangesAsync();
	}

	public async Task<Car> GetCarById(int id)
	{
		var cars = await _context.Cars.Where(x => x.Id == id)
			.Include(x => x.Cars_SpecialAbilities).ThenInclude(y => y.SpecialAbility)
			.Include(x => x.SellPlace)
			.Include(x => x.Cars_Awards).ThenInclude(y => y.Award).FirstOrDefaultAsync();

		return cars;
	}

	public async Task<IEnumerable<Car>> GetAll()
	{
		var result = await _context.Cars.Include(x => x.SellPlace).ToListAsync();
		return result;
	}

	public async Task<NewCarDropdownsVM> GetNewCarDropdownsValues()
	{
		var response = new NewCarDropdownsVM()
		{
			Awards = await _context.Awards.OrderBy(n => n.Name).ToListAsync(),
			SpecialAbilities = await _context.SpecialAbilities.OrderBy(n => n.Name).ToListAsync(),
			SellPlaces = await _context.SellPlaces.OrderBy(n => n.Name).ToListAsync()
		};

		return response;
	}

	public async Task UpdateCar(NewCarVM data)
	{
		var dbCar = await _context.Cars.FirstOrDefaultAsync(n => n.Id == data.Id);

		if (dbCar != null)
		{
			dbCar.Name = data.Name;
			dbCar.CarInfo = data.CarInfo;
			dbCar.Price = data.Price;
			dbCar.ImageURL = data.ImageURL;
			dbCar.StartSalesDate = data.StartSalesDate;
			dbCar.EndSalesDate = data.EndSalesDate;
			dbCar.CarType = data.CarType;
			dbCar.SellPlaceId = data.SellPlaceId;
			await _context.SaveChangesAsync();

		}

		//Remove existing awards
		var existingAwardsDb = _context.Cars_Awards.Where(n => n.CarId == data.Id).ToList();
		_context.Cars_Awards.RemoveRange(existingAwardsDb);
		await _context.SaveChangesAsync();

		//Add Car Awards
		foreach (var awardId in data.AwardIds)
		{
			var newCarAward = new Car_Award()
			{
				CarId = data.Id,
				AwardId = awardId
			};
			await _context.Cars_Awards.AddAsync(newCarAward);
		}

		//Remove existing special abilities
		var existingSpecialAbilitiesDb = _context.Cars_SpecialAbilities.Where(n => n.CarId == data.Id).ToList();
		_context.Cars_SpecialAbilities.RemoveRange(existingSpecialAbilitiesDb);
		await _context.SaveChangesAsync();

		//Add Car Special Abilities
		foreach (var specialAbilityId in data.SpecialAbilityIds)
		{
			var newCarSpecialAbility = new Car_SpecialAbility()
			{
				CarId = data.Id,
				SpecialAbilityId = specialAbilityId
			};
			await _context.Cars_SpecialAbilities.AddAsync(newCarSpecialAbility);
		}
		await _context.SaveChangesAsync();
	}
}