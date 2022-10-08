using CheapCars.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheapCars.Controllers;

public class CarsController : Controller
{
	private readonly CarDbContext _context;

	public CarsController(CarDbContext context)
	{
		_context = context;
	}
	public async Task<IActionResult> Index()
	{
		var cars = await _context.Cars.ToListAsync();
		return View(cars);
	}
}