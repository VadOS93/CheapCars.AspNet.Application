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

	[HttpGet]
	public async Task<IActionResult> Details(int id)
	{
		var awardDetails = await _awardService.Get(id);

		if (awardDetails == null)
			return View("NotFound");

		return View(awardDetails);
	}

	public async Task<IActionResult> Edit(int id)
	{
		var awardDetails = await _awardService.Get(id);

		if (awardDetails == null)
			return View("NotFound");
		return View(awardDetails);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, Award award)
	{
		var errors = ModelState.Values.SelectMany(v => v.Errors);
		if (!ModelState.IsValid)
		{
			return View(award);
		}
		await _awardService.Update(id, award);
		return RedirectToAction(nameof(Index));
	}

	public async Task<IActionResult> Delete(int id)
	{
		var awardDetails = await _awardService.Get(id);

		if (awardDetails == null)
			return View("NotFound");
		return View(awardDetails);
	}

	[HttpPost]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var awardDetails = await _awardService.Get(id);

		if (awardDetails == null)
			return View("NotFound");

		await _awardService.Delete(id);
		
		return RedirectToAction(nameof(Index));
	}
}