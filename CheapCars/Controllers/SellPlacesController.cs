using CheapCars.Data.Interfaces;
using CheapCars.Models;

using Microsoft.AspNetCore.Mvc;

namespace CheapCars.Controllers;

public class SellPlacesController : Controller
{
	private readonly ISellPlacesService _sellPlacesService;

	public SellPlacesController(ISellPlacesService sellPlacesService)
	{
		_sellPlacesService = sellPlacesService;
	}

	public async Task<IActionResult> Index()
	{
		var sellPlaces = await _sellPlacesService.GetAll();
		return View(sellPlaces);
	}

	public ActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(SellPlace sellPlace)
	{
		var errors = ModelState.Values.SelectMany(v => v.Errors);
		if (!ModelState.IsValid)
		{
			return View(sellPlace);
		}
		await _sellPlacesService.Add(sellPlace);
		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public async Task<IActionResult> Details(int id)
	{
		var sellPlaceDetails = await _sellPlacesService.Get(id);

		if (sellPlaceDetails == null)
			return View("NotFound");

		return View(sellPlaceDetails);
	}

	public async Task<IActionResult> Edit(int id)
	{
		var sellPlaceDetails = await _sellPlacesService.Get(id);

		if (sellPlaceDetails == null)
			return View("NotFound");
		return View(sellPlaceDetails);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, SellPlace sellPlace)
	{
		var errors = ModelState.Values.SelectMany(v => v.Errors);
		if (!ModelState.IsValid)
		{
			return View(sellPlace);
		}
		await _sellPlacesService.Update(id, sellPlace);
		return RedirectToAction(nameof(Index));
	}

	public async Task<IActionResult> Delete(int id)
	{
		var sellPlaceDetails = await _sellPlacesService.Get(id);

		if (sellPlaceDetails == null)
			return View("NotFound");
		return View(sellPlaceDetails);
	}

	[HttpPost]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var sellPlaceDetails = await _sellPlacesService.Get(id);

		if (sellPlaceDetails == null)
			return View("NotFound");

		await _sellPlacesService.Delete(id);

		return RedirectToAction(nameof(Index));
	}
}