using CheapCars.Data.Services;

namespace CheapCars.Data.Extensions.DI;

public static class ServiceActivator
{
	public static IServiceCollection ActivateBasicServices(this IServiceCollection services)
	{
		services.AddScoped<IAwardsService, AwardsService>();
		return services;
	}
}