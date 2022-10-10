using CheapCars.Models;

namespace CheapCars.Data.Services;

public interface IAwardsService
{
	Task<IEnumerable<Award>> GetAll();
	Award Get(int id);
	void Add(Award award);
	Award Update(int id, Award newAward);
	void Delete(int id);
}