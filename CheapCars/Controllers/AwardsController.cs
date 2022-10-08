using CheapCars.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheapCars.Controllers;

public class AwardsController : Controller
{
	private readonly CarDbContext _context;

	public AwardsController(CarDbContext context)
	{
		_context = context;
	}

	public async Task<IActionResult> Index()
	{
		var awards = await _context.Awards.ToListAsync();
		return View(awards);
	}
}