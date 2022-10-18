using CheapCars.Models;
using Microsoft.EntityFrameworkCore;

namespace CheapCars.Data.Services;

internal sealed class SpecialAbilitiesService : ISpecialAbilitiesService
{
	private readonly CarDbContext _context;

	public SpecialAbilitiesService(CarDbContext context)
	{
		_context = context;
	}

	public async Task Add(SpecialAbility specialAbility)
	{
		await _context.SpecialAbilities.AddAsync(specialAbility);
		await _context.SaveChangesAsync();
	}

	public async Task Delete(int id)
	{
		var result = await _context.SpecialAbilities.FirstOrDefaultAsync(x => x.Id == id);
		_context.SpecialAbilities.Remove(result);
		await _context.SaveChangesAsync();
	}

	public async Task<SpecialAbility> Get(int id)
	{
		var result = await _context.SpecialAbilities.FirstOrDefaultAsync(x => x.Id == id);
		return result;
	}

	public async Task<IEnumerable<SpecialAbility>> GetAll()
	{
		var result = await _context.SpecialAbilities.ToListAsync();
		return result;
	}

	public async Task<SpecialAbility> Update(int id, SpecialAbility newSpecialAbility)
	{
		_context.Update(newSpecialAbility);
		await _context.SaveChangesAsync();
		return newSpecialAbility;
	}
}