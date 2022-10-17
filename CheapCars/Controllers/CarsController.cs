using CheapCars.Data;
using CheapCars.Data.Services;
using CheapCars.Data.Static;
using CheapCars.Data.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CheapCars.Controllers;

[Authorize(Roles = UserRoles.Admin)]
public class CarsController : Controller
{
	private readonly CarDbContext _context;
	private readonly ICarsService _carService;

	public CarsController(CarDbContext context, ICarsService carService)
	{
		_context = context;
		_carService = carService;
	}

	[AllowAnonymous]
	public async Task<IActionResult> Available(int page = 1)
	{
		var allCars = await _carService.GetAll();

		var filteredResult = allCars.Where(x => x.StartSalesDate < DateTime.UtcNow && x.EndSalesDate > DateTime.UtcNow).ToList();

		var carsView = new CarViewModel
		{
			CarPerPage = 3,
			Cars = filteredResult,
			CurrentPage = page
		};

		return View("Index", carsView);

	}

	[AllowAnonymous]
	public async Task<IActionResult> SortByAsc(int page = 1)
	{
		var allCars = await _carService.GetAll();

		var filteredResult = allCars.ToList().OrderBy(x => x.Price);

		var carsView = new CarViewModel
		{
			CarPerPage = 3,
			Cars = filteredResult,
			CurrentPage = page
		};

		return View("Index", carsView);

	}

	[AllowAnonymous]
	public async Task<IActionResult> SortByDesc(int page = 1)
	{
		var allCars = await _carService.GetAll();

		var filteredResult = allCars.ToList().OrderByDescending(x => x.Price);

		var carsView = new CarViewModel
		{
			CarPerPage = 3,
			Cars = filteredResult,
			CurrentPage = page
		};

		return View("Index", carsView);
	}

	[AllowAnonymous]
	public async Task<IActionResult> Filter(string searchString)
	{
		var allCars = await _carService.GetAll();

		if (!string.IsNullOrEmpty(searchString))
		{
			var filteredResult = allCars.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.CarInfo.ToLower().Contains(searchString.ToLower())).ToList().OrderBy(x => x.Price);

			//var filteredResultNew = allCars.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.CarInfo, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

			return View("Index", filteredResult);
		}

		return View("Index", allCars);
	}

	[AllowAnonymous]
	public async Task<IActionResult> Index(int page = 1)
	{
		var carsView = new CarViewModel
		{
			CarPerPage = 3,
			Cars = _context.Cars.Include(x => x.SellPlace).OrderBy(x => x.Name),
			CurrentPage = page
		};
		return View(carsView);

	}

	[AllowAnonymous]
	public async Task<IActionResult> Details(int id)
	{
		var car = await _carService.GetCarById(id);
		return View(car);
	}

	public async Task<IActionResult> Create()
	{
		var carDropdownsData = await _carService.GetNewCarDropdownsValues();

		ViewBag.SpecialAbilities = new SelectList(carDropdownsData.SpecialAbilities, "Id", "Name");
		ViewBag.SellPlaces = new SelectList(carDropdownsData.SellPlaces, "Id", "Name");
		ViewBag.Awards = new SelectList(carDropdownsData.Awards, "Id", "Name");

		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(NewCarVM car)
	{
		if (!ModelState.IsValid)
		{
			var carDropdownsData = await _carService.GetNewCarDropdownsValues();

			ViewBag.SpecialAbilities = new SelectList(carDropdownsData.SpecialAbilities, "Id", "Name");
			ViewBag.SellPlaces = new SelectList(carDropdownsData.SellPlaces, "Id", "Name");
			ViewBag.Awards = new SelectList(carDropdownsData.Awards, "Id", "Name");

			return View(car);
		}

		await _carService.AddNewCar(car);
		return RedirectToAction(nameof(Index));
	}

	public async Task<IActionResult> Edit(int id)
	{
		var carDetails = await _carService.GetCarById(id);
		if (carDetails == null) return View("NotFound");

		var response = new NewCarVM()
		{
			Id = carDetails.Id,
			Name = carDetails.Name,
			CarInfo = carDetails.CarInfo,
			Price = carDetails.Price,
			StartSalesDate = carDetails.StartSalesDate,
			EndSalesDate = carDetails.EndSalesDate,
			ImageURL = carDetails.ImageURL,
			CarType = carDetails.CarType,
			SpecialAbilityIds = carDetails.Cars_SpecialAbilities.Select(x => x.SpecialAbilityId).ToList(),
			SellPlaceId = carDetails.SellPlaceId,
			AwardIds = carDetails.Cars_Awards.Select(x => x.AwardId).ToList()
		};

		var carDropdownsData = await _carService.GetNewCarDropdownsValues();

		ViewBag.SpecialAbilities = new SelectList(carDropdownsData.SpecialAbilities, "Id", "Name");
		ViewBag.SellPlaces = new SelectList(carDropdownsData.SellPlaces, "Id", "Name");
		ViewBag.Awards = new SelectList(carDropdownsData.Awards, "Id", "Name");

		return View(response);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, NewCarVM car)
	{
		if (id != car.Id) return View("NotFound");

		if (!ModelState.IsValid)
		{
			var carDropdownsData = await _carService.GetNewCarDropdownsValues();

			ViewBag.SpecialAbilities = new SelectList(carDropdownsData.SpecialAbilities, "Id", "Name");
			ViewBag.SellPlaces = new SelectList(carDropdownsData.SellPlaces, "Id", "Name");
			ViewBag.Awards = new SelectList(carDropdownsData.Awards, "Id", "Name");

			return View(car);
		}

		await _carService.UpdateCar(car);
		return RedirectToAction(nameof(Index));
	}
}