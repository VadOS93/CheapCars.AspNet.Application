using CheapCars.Data;
using CheapCars.Data.Extensions.DI;

using Microsoft.EntityFrameworkCore;

namespace CheapCars;

public class Program
{
	public static void Main(string[] args)
	{
		IConfiguration configuration = new ConfigurationBuilder()
							.AddJsonFile("appsettings.json")
							.Build();

		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddDbContext<CarDbContext>(options => 
		{
			options.UseSqlServer(configuration.GetConnectionString("Default")); 
		});


		builder.Services.ActivateBasicServices();
		builder.Services.AddControllersWithViews();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthorization();

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		//Seed database
		CarDbInitializer.SeedData(app);
		 
		app.Run();

	}
}