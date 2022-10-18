using CheapCars.Models;

namespace CheapCars.Data.Services;

public interface ISpecialAbilitiesService
{
	Task Add(SpecialAbility specialAbility);
	Task Delete(int id);
	Task<SpecialAbility> Get(int id);
	Task<IEnumerable<SpecialAbility>> GetAll();
	Task<SpecialAbility> Update(int id, SpecialAbility newSpecialAbility);
}