using CheapCars.Data.Static;
using CheapCars.Models;
using CheapCars.Models.Joins;

using Microsoft.AspNetCore.Identity;

namespace CheapCars.Data;

public class CarDbInitializer
{
	public static void SeedData(IApplicationBuilder applicationBuilder)
	{
		using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
		{
			var context = serviceScope.ServiceProvider.GetService<CarDbContext>();

			context.Database.EnsureCreated();

			//SpecialAbilities
			if (!context.SpecialAbilities.Any())
			{
				context.SpecialAbilities.AddRange(new List<SpecialAbility>()
				{
					new SpecialAbility()
					{
						Name = "Fast acceleration",
						Description = "A cehicle has a big power with low weight, which gives you an opportunity to run fast",
						SpecialAbilityURLPicture = "https://images.unsplash.com/photo-1498887960847-2a5e46312788?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1469&q=80"
					},
					new SpecialAbility()
					{
						Name = "Low fuel consumption",
						Description = "Use of lower amount of fuel comparing with the average vehicle",
						SpecialAbilityURLPicture = "https://images.unsplash.com/photo-1602853175733-5ad62dc6a2c8?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1439&q=80"

					},
					new SpecialAbility()
					{
						Name = "Safe for children",
						Description = "There are safety panels to prevent children to push occasionally an important button",
						SpecialAbilityURLPicture = "https://plus.unsplash.com/premium_photo-1661288476987-8ed1d2085133?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80"

					},
					new SpecialAbility()
					{
						Name = "Big capacity",
						Description = "A vehicle can take a big number of passengers (more than 5) or can carry a weight over 2 tons",
						SpecialAbilityURLPicture = "https://media.istockphoto.com/id/147268654/uk/%D1%84%D0%BE%D1%82%D0%BE/%D0%B1%D1%96%D0%BB%D0%B0-%D0%B2%D0%B0%D0%BD%D1%82%D0%B0%D0%B6%D1%96%D0%B2%D0%BA%D0%B0-%D1%97%D0%B4%D0%B5-%D0%BF%D0%BE-%D0%B4%D0%BE%D1%80%D0%BE%D0%B7%D1%96-%D0%BF%D0%B5%D1%80%D0%B5%D0%B2%D0%BE%D0%B7%D1%8F%D1%87%D0%B8-%D0%BA%D1%83%D0%BF%D1%83-%D1%81%D0%BC%D1%96%D1%82%D1%82%D1%8F.jpg?s=1024x1024&w=is&k=20&c=nsCeG0f-P8LGxrXOziyGc6roEwGNIiT1wyq-JIlboE8="
					},
					new SpecialAbility()
					{
						Name = "Easy to manage",
						Description = "A vehicle is easily manageable in terms of who is a driver: newbie or professional. Everyone can get used to driving without any difficulties",
						SpecialAbilityURLPicture = "https://images.unsplash.com/photo-1524841268495-3921a3fb80c3?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=688&q=80"
					}
				});
				context.SaveChanges();
			}

			//Awards
			if (!context.Awards.Any())
			{
				context.Awards.AddRange(new List<Award>()
				{
					new Award()
					{
						Name = "Popular",
						Description = "The most widespead car in terms of sales during several last years",
						Logo =  "https://image.shutterstock.com/image-vector/red-vector-banner-ribbon-most-600w-1140863741.jpg"
					},
					new Award()
					{
						Name = "Comfort",
						Description = "The car is comfortable for the whole family and even for pets",
						Logo = "https://image.shutterstock.com/image-vector/high-comfort-zone-item-fabric-600w-1729989856.jpg"
					},
					new Award()
					{
						Name = "High Power",
						Description = "Great controle of speed, power and driving",
						Logo = "https://image.shutterstock.com/image-vector/black-lightning-bolt-circle-simple-600w-1385663936.jpg"
					},
					new Award()
					{
						Name = "Reliable",
						Description = "The car shows big reliability during last 5+ years",
						Logo = "https://image.shutterstock.com/image-vector/car-shield-sign-icon-logo-600w-1884790816.jpg"
					}
				});
				context.SaveChanges();
			}

			//SellPlaces
			if (!context.SellPlaces.Any())
			{
				context.SellPlaces.AddRange(new List<SellPlace>()
				{
					new SellPlace()
					{
						Name = "J.D.Power",
						Description = "Most anyone who has owned a car knows there comes the point when it’s time to sell. Perhaps it’s a convertible you don’t often use or a handy pickup truck that’s no longer needed, or maybe a dealer wouldn’t offer you a fair price in trade when you bought a new car. Regardless of the reason, you’re now a seller looking for a buyer.",
						SellPlaceURLPicture = "https://cdn.jdpower.com/JDPA_Car%20Dealership%20erik%20mclean%20unsplash.jpg"
					},
					new SellPlace()
					{
						Name = "Motorway",
						Description = "When selling a car, the first option that comes to mind for many is to sell to a car dealer — either directly or as a part exchange. Dealers have been buying cars from motorists across the UK since the dawn of the combustion engine.",
						SellPlaceURLPicture = "https://motorway-blog.imgix.net/2021/06/Car_dealership.png?auto=compress,format&w=960"
					}
				});
				context.SaveChanges();
			}

			//Cars
			if (!context.Cars.Any())
			{
				context.Cars.AddRange(new List<Car>()
				{
					new Car()
					{
						Name = "Volkswagen Passat",
						CarInfo = "German reliable car for everyone",
						Price = 7000,
						ImageURL = "https://image.shutterstock.com/image-photo/riga-latvia-7-november-2019-600w-1552986002.jpg",
						StartSalesDate = DateTime.UtcNow.AddDays(1),
						EndSalesDate = DateTime.UtcNow.AddDays(4),
						SellPlaceId = 1,
						CarType = Enums.CarType.Sedan
					},
					new Car()
					{
						Name = "Opel Zafira",
						CarInfo = "Car for the family",
						Price = 6000,
						ImageURL = "https://image.shutterstock.com/image-photo/lisnice-czech-republic-october-20-600w-781072687.jpg",
						StartSalesDate = DateTime.UtcNow.AddDays(-2),
						EndSalesDate = DateTime.UtcNow.AddDays(2),
						SellPlaceId = 2,
						CarType = Enums.CarType.Minivan
					},
					new Car()
					{
						Name = "Volkswagen Gold",
						CarInfo = "Fast and stylish car with middle capacity",
						Price = 9000,
						ImageURL = "https://image.shutterstock.com/image-photo/gothenburg-sweden-july-21-2018-600w-1453806899.jpg",
						StartSalesDate = DateTime.UtcNow.AddDays(-4),
						EndSalesDate = DateTime.UtcNow.AddDays(-2),
						SellPlaceId = 1,
						CarType = Enums.CarType.Hatchback
					}
				});
				context.SaveChanges();
			}

			//Cars & Awards
			if (!context.Cars_Awards.Any())
			{
				context.Cars_Awards.AddRange(new List<Car_Award>()
				{
					new Car_Award()
					{
						AwardId = 3,
						CarId = 1
					},
					new Car_Award()
					{
						AwardId = 4,
						CarId = 1
					},
					new Car_Award()
					{
						AwardId = 1,
						CarId = 2
					},
					new Car_Award()
					{
						AwardId = 2,
						CarId = 2
					},
					new Car_Award()
					{
						AwardId = 3,
						CarId = 3
					},
					new Car_Award()
					{
						AwardId = 2,
						CarId = 3
					}
				});
				context.SaveChanges();
			}

			//Cars & SpecialAbilities
			if (!context.Cars_SpecialAbilities.Any())
			{
				context.Cars_SpecialAbilities.AddRange(new List<Car_SpecialAbility>()
				{
					new Car_SpecialAbility()
					{
						CarId = 1,
						SpecialAbilityId = 1
					},
					new Car_SpecialAbility()
					{
						CarId = 1,
						SpecialAbilityId = 2
					},
					new Car_SpecialAbility()
					{
						CarId = 2,
						SpecialAbilityId = 2
					},
					new Car_SpecialAbility()
					{
						CarId = 2,
						SpecialAbilityId = 3
					},
					new Car_SpecialAbility()
					{
						CarId = 2,
						SpecialAbilityId = 4
					},
					new Car_SpecialAbility()
					{
						CarId = 2,
						SpecialAbilityId = 5
					},
					new Car_SpecialAbility()
					{
						CarId = 3,
						SpecialAbilityId = 1
					},
					new Car_SpecialAbility()
					{
						CarId = 3,
						SpecialAbilityId = 5
					}
				});
				context.SaveChanges();
			}
		}
	}
	public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
	{
		using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
		{

			//Roles
			var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
				await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
			if (!await roleManager.RoleExistsAsync(UserRoles.User))
				await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

			//Users
			var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			string adminUserEmail = "admin@cheapcars.com";

			var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
			if (adminUser == null)
			{
				var newAdminUser = new ApplicationUser()
				{
					FullName = "Admin User",
					UserName = "admin",
					Email = adminUserEmail,
					EmailConfirmed = true
				};
				await userManager.CreateAsync(newAdminUser, "Coding12345!!!");
				await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
			}


			string appUserEmail = "user@cheapcars.com";

			var appUser = await userManager.FindByEmailAsync(appUserEmail);
			if (appUser == null)
			{
				var newAppUser = new ApplicationUser()
				{
					FullName = "Application User",
					UserName = "user",
					Email = appUserEmail,
					EmailConfirmed = true
				};
				await userManager.CreateAsync(newAppUser, "Coding12345!!!");
				await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
			}
		}
	}
}