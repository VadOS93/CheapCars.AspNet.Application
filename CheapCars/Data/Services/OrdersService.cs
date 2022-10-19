using CheapCars.Data.Interfaces;
using CheapCars.Models;

using Microsoft.EntityFrameworkCore;

namespace CheapCars.Data.Services;

internal sealed class OrdersService : IOrdersService
{
	private readonly CarDbContext _context;
	public OrdersService(CarDbContext context)
	{
		_context = context;
	}

	public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
	{
		var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Car).Include(n => n.User).ToListAsync();

		if (userRole != "Admin")
		{
			orders = orders.Where(n => n.UserId == userId).ToList();
		}

		return orders;
	}

	public async Task StoreOrderAsync(List<BusketItem> items, string userId, string userEmailAddress)
	{
		var order = new Order()
		{
			UserId = userId,
			Email = userEmailAddress
		};
		await _context.Orders.AddAsync(order);
		await _context.SaveChangesAsync();

		foreach (var item in items)
		{
			var orderItem = new OrderItem()
			{
				Amount = item.Amount,
				CarId = item.Car.Id,
				OrderId = order.Id,
				Price = item.Car.Price
			};
			await _context.OrderItems.AddAsync(orderItem);
		}
		await _context.SaveChangesAsync();
	}
}