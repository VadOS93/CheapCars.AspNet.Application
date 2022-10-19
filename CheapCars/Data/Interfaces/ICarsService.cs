using CheapCars.Data.ViewModels;
using CheapCars.Models;

namespace CheapCars.Data.Interfaces;

public interface ICarsService
{
    Task<Car> GetCarById(int id);
    Task<NewCarDropdownsVM> GetNewCarDropdownsValues();
    Task AddNewCar(NewCarVM data);
    Task UpdateCar(NewCarVM data);
    Task<IEnumerable<Car>> GetAll();
}