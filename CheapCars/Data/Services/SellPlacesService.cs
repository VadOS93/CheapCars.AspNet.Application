using CheapCars.Data.Interfaces;
using CheapCars.Models;
using Microsoft.EntityFrameworkCore;

namespace CheapCars.Data.Services;

internal sealed class SellPlacesService: ISellPlacesService
{
	private readonly CarDbContext _context;

	public SellPlacesService(CarDbContext context)
	{
		_context = context;
	}

	public async Task Add(SellPlace sellPlace)
	{
		await _context.SellPlaces.AddAsync(sellPlace);
		await _context.SaveChangesAsync();
	}

	public async Task Delete(int id)
	{
		var result = await _context.SellPlaces.FirstOrDefaultAsync(x => x.Id == id);
		_context.SellPlaces.Remove(result);
		await _context.SaveChangesAsync();
	}

	public async Task<SellPlace> Get(int id)
	{
		var result = await _context.SellPlaces.FirstOrDefaultAsync(x => x.Id == id);
		return result;
	}

	public async Task<IEnumerable<SellPlace>> GetAll()
	{
		var result = await _context.SellPlaces.ToListAsync();
		return result;
	}

	public async Task<SellPlace> Update(int id, SellPlace newSellPlace)
	{
		_context.Update(newSellPlace);
		await _context.SaveChangesAsync();
		return newSellPlace;
	}
}