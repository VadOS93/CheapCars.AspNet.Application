using CheapCars.Data.Services;

using Microsoft.AspNetCore.Mvc;

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
}