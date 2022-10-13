using CheapCars.Models;

using Microsoft.EntityFrameworkCore;

using System;

namespace CheapCars.Data;

public class Busket
{
	public CarDbContext _context { get; set; }

	public string BusketId { get; set; }
	public List<BusketItem> BusketItems { get; set; }

	public Busket(CarDbContext context)
	{
		_context = context;
	}

	public static Busket GetBusket(IServiceProvider services)
	{
		ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
		var context = services.GetService<CarDbContext>();

		string busketId = session.GetString("BusketId") ?? Guid.NewGuid().ToString();
		session.SetString("BusketId", busketId);

		return new Busket(context) { BusketId = busketId };
	}

	public void AddItemToBusket(Car car)
	{
		var shoppingCartItem = _context.BusketItems.FirstOrDefault(n => n.Car.Id == car.Id && n.BusketId == BusketId);

		if (shoppingCartItem == null)
		{
			shoppingCartItem = new BusketItem()
			{
				BusketId = BusketId,
				Car = car,
				Amount = 1
			};

			_context.BusketItems.Add(shoppingCartItem);
		}
		else
		{
			shoppingCartItem.Amount++;
		}
		_context.SaveChanges();
	}

	public void RemoveItemFromBusket(Car car)
	{
		var shoppingCartItem = _context.BusketItems.FirstOrDefault(n => n.Car.Id == car.Id && n.BusketId == BusketId);

		if (shoppingCartItem != null)
		{
			if (shoppingCartItem.Amount > 1)
			{
				shoppingCartItem.Amount--;
			}
			else
			{
				_context.BusketItems.Remove(shoppingCartItem);
			}
		}
		_context.SaveChanges();
	}

	public List<BusketItem> GetBusketItems()
	{
		return BusketItems ?? (BusketItems = _context.BusketItems.Where(n => n.BusketId == BusketId).Include(n => n.Car).ToList());
	}

	public double GetBusketTotal() => _context.BusketItems.Where(n => n.BusketId == BusketId).Select(n => n.Car.Price * n.Amount).Sum();

	public async Task ClearBusketAsync()
	{
		var items = await _context.BusketItems.Where(n => n.BusketId == BusketId).ToListAsync();
		_context.BusketItems.RemoveRange(items);
		await _context.SaveChangesAsync();
	}
}