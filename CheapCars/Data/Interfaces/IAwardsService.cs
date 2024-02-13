﻿using CheapCars.Models;

namespace CheapCars.Data.Interfaces;

/// <summary>
/// Award Service interface
/// </summary>
public interface IAwardsService
{
    Task<IEnumerable<Award>> GetAll();
    Task<Award> Get(int id);
    Task Add(Award award);
    Task<Award> Update(int id, Award newAward);
    Task Delete(int id);
}