using CheapCars.Models;

namespace CheapCars.Data.Interfaces;

public interface ISellPlacesService
{
    Task Add(SellPlace sellPlace);
    Task Delete(int id);
    Task<SellPlace> Get(int id);
    Task<IEnumerable<SellPlace>> GetAll();
    Task<SellPlace> Update(int id, SellPlace newSellPlace);
}