using CheapCars.Models;

using Microsoft.EntityFrameworkCore;

namespace CheapCars.Data.Services;

public class AwardsService : IAwardsService
{
	private readonly CarDbContext _context;

	public AwardsService(CarDbContext context)
	{
		_context = context;
	}

	public void Add(Award award)
	{
		throw new NotImplementedException();
	}

	public void Delete(int id)
	{
		throw new NotImplementedException();
	}

	public Award Get(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Award>> GetAll()
	{
		var result = await _context.Awards.ToListAsync();
		return result;
	}

	public Award Update(int id, Award newAward)
	{
		throw new NotImplementedException();
	}
}