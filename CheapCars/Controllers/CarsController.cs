using CheapCars.Data;
using CheapCars.Data.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheapCars.Controllers;

public class CarsController : Controller
{
	private readonly CarDbContext _context;
	private readonly ICarsService _carService;

	public CarsController(CarDbContext context, ICarsService carService)
	{
		_context = context;
		_carService = carService;
	}
	public async Task<IActionResult> Index()
	{
		var cars = await _context.Cars.Include(x => x.SellPlace).OrderBy(x => x.Name).ToListAsync();
		return View(cars);
	}

	[AllowAnonymous]
	public async Task<IActionResult> Details(int id)
	{
		var car = await _carService.GetCarById(id);
		return View(car);
	}
}