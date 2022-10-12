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

	public async Task Add(Award award)
	{
		await _context.Awards.AddAsync(award);
		await _context.SaveChangesAsync();
	}

	public async Task Delete(int id)
	{
		var result = await _context.Awards.FirstOrDefaultAsync(x => x.Id == id);
		_context.Awards.Remove(result);
		await _context.SaveChangesAsync();
	}

	public async Task<Award> Get(int id)
	{
		var result = await _context.Awards.FirstOrDefaultAsync(x => x.Id == id);
		return result;
	}

	public async Task<IEnumerable<Award>> GetAll()
	{
		var result = await _context.Awards.ToListAsync();
		return result;
	}

	public async Task<Award> Update(int id, Award newAward)
	{
		_context.Update(newAward);
		await _context.SaveChangesAsync();
		return newAward;
	}
}