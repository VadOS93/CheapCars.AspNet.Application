using CheapCars.Data.Services;
using CheapCars.Models;

using Microsoft.AspNetCore.Mvc;

using StackExchange.Redis;

namespace CheapCars.Controllers;

public class AwardsController : Controller
{
	private readonly IAwardsService _awardService;

	public AwardsController(IAwardsService awardService)
	{
		_awardService = awardService;
	}

	public async Task<IActionResult> Index()
	{
		var awards = await _awardService.GetAll();
		return View(awards);
	}

	public ActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(Award award)
	{
		var errors = ModelState.Values.SelectMany(v => v.Errors);
		if (!ModelState.IsValid)
		{
			return View(award);
		}
		await _awardService.Add(award);
		return RedirectToAction(nameof(Index));
	}
}