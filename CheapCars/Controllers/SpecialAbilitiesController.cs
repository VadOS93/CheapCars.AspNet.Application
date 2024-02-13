using CheapCars.Data.Interfaces;
using CheapCars.Models;

using Microsoft.AspNetCore.Mvc;

namespace CheapCars.Controllers;

/// <summary>
/// Operations with special abilities
/// </summary>
public class SpecialAbilitiesController : Controller
{
	private readonly ISpecialAbilitiesService _specialAbilitiesService;

	public SpecialAbilitiesController(ISpecialAbilitiesService specialAbilitiesService)
	{
		_specialAbilitiesService = specialAbilitiesService;
	}

	public async Task<IActionResult> Index()
	{
		var specialAbilities = await _specialAbilitiesService.GetAll();
		return View(specialAbilities);
	}

	public ActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(SpecialAbility specialAbility)
	{
		var errors = ModelState.Values.SelectMany(v => v.Errors);
		if (!ModelState.IsValid)
			return View(specialAbility);

		await _specialAbilitiesService.Add(specialAbility);
		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public async Task<IActionResult> Details(int id)
	{
		var specialAbilityDetails = await _specialAbilitiesService.Get(id);

		if (specialAbilityDetails is null)
			return View("NotFound");

		return View(specialAbilityDetails);
	}

	public async Task<IActionResult> Edit(int id)
	{
		var specialAbilityDetails = await _specialAbilitiesService.Get(id);

		if (specialAbilityDetails is null)
			return View("NotFound");

		return View(specialAbilityDetails);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, SpecialAbility specialAbility)
	{
		var errors = ModelState.Values.SelectMany(v => v.Errors);

		if (!ModelState.IsValid)
			return View(specialAbility);

		await _specialAbilitiesService.Update(id, specialAbility);
		return RedirectToAction(nameof(Index));
	}

	public async Task<IActionResult> Delete(int id)
	{
		var specialAbilityDetails = await _specialAbilitiesService.Get(id);

		if (specialAbilityDetails is null)
			return View("NotFound");

		return View(specialAbilityDetails);
	}

	[HttpPost]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var specialAbilityDetails = await _specialAbilitiesService.Get(id);

		if (specialAbilityDetails is null)
			return View("NotFound");

		await _specialAbilitiesService.Delete(id);

		return RedirectToAction(nameof(Index));
	}
}