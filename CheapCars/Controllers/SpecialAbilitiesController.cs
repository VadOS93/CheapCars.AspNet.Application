using CheapCars.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheapCars.Controllers;

public class SpecialAbilitiesController : Controller
{
	private readonly CarDbContext _context;

	public SpecialAbilitiesController(CarDbContext context)
	{
		_context = context;
	}
	public async Task<IActionResult> Index()
	{
		var specialAbilities = await _context.SpecialAbilities.ToListAsync();
		return View(specialAbilities);
	}
}