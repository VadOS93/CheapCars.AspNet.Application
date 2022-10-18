using CheapCars.Data.Services;

namespace CheapCars.Data.Extensions.DI;

public static class ServiceActivator
{
	public static IServiceCollection ActivateBasicServices(this IServiceCollection services)
	{
		services.AddScoped<ICarsService, CarsService>();
		services.AddScoped<IAwardsService, AwardsService>();
		services.AddScoped<IOrdersService, OrdersService>();
		services.AddScoped<ISellPlacesService, SellPlacesService>();
		services.AddScoped<ISpecialAbilitiesService, SpecialAbilitiesService>();
		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		services.AddScoped(sc => Busket.GetBusket(sc));
		return services;
	}
}