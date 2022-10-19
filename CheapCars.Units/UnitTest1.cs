using CheapCars.Controllers;
using CheapCars.Data.Services;
using CheapCars.Data.ViewModels;
using CheapCars.Models;

using FakeItEasy;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Xunit;

namespace CheapCars.Units;

public class UnitTest1
{
	private ICarsService _carService;
	private CarsController _carsController;
	public UnitTest1()
	{
		_carService = A.Fake<ICarsService>();
		_carsController = new CarsController(_carService);
	}

	[Fact]
	public void CarsController_Index_ReturnsSuccess()
	{
		//Arrange
		var cars = A.Fake<IEnumerable<Car>>();
		A.CallTo(() => _carService.GetAll()).Returns(cars);
		//Act
		var result = _carsController.Index();
		//Assert
		result.Should().BeOfType<Task<IActionResult>>();
	}

	[Fact]
	public void CarsController_Available_ReturnsSuccess()
	{
		//Arrange
		var cars = A.Fake<IEnumerable<Car>>();
		A.CallTo(() => _carService.GetAll()).Returns(cars);
		//Act
		var result = _carsController.Available();
		//Assert
		result.Should().BeOfType<Task<IActionResult>>();
	}

	[Fact]
	public void CarsController_Filter_ReturnsSuccess()
	{
		//Arrange
		var cars = A.Fake<IEnumerable<Car>>();
		A.CallTo(() => _carService.GetAll()).Returns(cars);
		//Act
		var result = _carsController.Filter("opel");
		//Assert
		result.Should().BeOfType<Task<IActionResult>>();
	}

	[Fact]
	public void CarsController_SortByAsc_ReturnsSuccess()
	{
		//Arrange
		var cars = A.Fake<IEnumerable<Car>>();
		A.CallTo(() => _carService.GetAll()).Returns(cars);
		//Act
		var result = _carsController.SortByAsc();
		//Assert
		result.Should().BeOfType<Task<IActionResult>>();
	}

	[Fact]
	public void CarsController_SortByDesc_ReturnsSuccess()
	{
		//Arrange
		var cars = A.Fake<IEnumerable<Car>>();
		A.CallTo(() => _carService.GetAll()).Returns(cars);
		//Act
		var result = _carsController.SortByDesc();
		//Assert
		result.Should().BeOfType<Task<IActionResult>>();
	}

	[Fact]
	public void CarsController_Details_ReturnsSuccess()
	{
		//Arrange
		var id = 1;
		var car = A.Fake<Car>();
		A.CallTo(() => _carService.GetCarById(id)).Returns(car);
		//Act
		var result = _carsController.Details(id);
		//Assert
		result.Should().BeOfType<Task<IActionResult>>();
	}

	[Fact]
	public void CarsController_Create_ReturnsSuccess()
	{
		//Arrange
		var car = A.Fake<NewCarVM>();
		A.CallTo(() => _carService.AddNewCar(car));
		//Act
		var result = _carsController.Create(car);
		//Assert
		result.Should().BeOfType<Task<IActionResult>>();
	}

	[Fact]
	public void CarsController_Edit_ReturnsSuccess()
	{
		//Arrange
		var id = 1;
		var car = A.Fake<NewCarVM>();
		A.CallTo(() => _carService.UpdateCar(car));
		//Act
		var result = _carsController.Edit(id, car);
		//Assert
		result.Should().BeOfType<Task<IActionResult>>();
	}
}