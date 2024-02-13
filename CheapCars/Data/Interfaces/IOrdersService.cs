﻿using CheapCars.Models;

namespace CheapCars.Data.Interfaces;

/// <summary>
/// Orders service interface
/// </summary>
public interface IOrdersService
{
    Task StoreOrderAsync(List<BusketItem> items, string userId, string userEmailAddress);
    Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
}