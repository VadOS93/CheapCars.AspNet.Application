using CheapCars.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheapCars.Controllers;

public class SellPlacesController : Controller
{
	private readonly CarDbContext _context;

	public SellPlacesController(CarDbContext context)
	{
		_context = context;
	}

	public async Task<IActionResult> Index()
	{
		var sellPlaces = await _context.SellPlaces.ToListAsync();
		return View(sellPlaces);
	}
}