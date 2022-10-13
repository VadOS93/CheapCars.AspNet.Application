using CheapCars.Models;

namespace CheapCars.Data.Services;

public interface IOrdersService
{
	Task StoreOrderAsync(List<BusketItem> items, string userId, string userEmailAddress);
	Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
}