﻿using Microsoft.AspNetCore.Mvc;

namespace CheapCars.Data.ViewComponents;

public class BusketSummary : ViewComponent
{
	private readonly Busket _busket;
	public BusketSummary(Busket busket)
	{
		_busket = busket;
	}

	public IViewComponentResult Invoke()
	{
		var items = _busket.GetBusketItems();

		return View(items.Count);
	}
}