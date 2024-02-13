using CheapCars.Models;
using CheapCars.Models.Joins;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CheapCars.Data;

/// <summary>
/// Car Db Context
/// </summary>
public class CarDbContext : IdentityDbContext<ApplicationUser>
{
	public DbSet<Award> Awards { get; set; }
	public DbSet<Car> Cars { get; set; }
	public DbSet<SpecialAbility> SpecialAbilities { get; set; }
	public DbSet<SellPlace> SellPlaces { get; set; }
	public DbSet<Car_Award> Cars_Awards { get; set; }
	public DbSet<Car_SpecialAbility> Cars_SpecialAbilities { get; set; }

	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderItem> OrderItems { get; set; }
	public DbSet<BusketItem> BusketItems { get; set; }

	public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Car_Award>().HasKey(x => new
		{
			x.CarId,
			x.AwardId
		});

		modelBuilder.Entity<Car_Award>()
			.HasOne(x => x.Award)
			.WithMany(y => y.Cars_Awards)
			.HasForeignKey(x => x.AwardId);

		modelBuilder.Entity<Car_Award>()
			.HasOne(x => x.Car)
			.WithMany(y => y.Cars_Awards)
			.HasForeignKey(x => x.CarId);

		modelBuilder.Entity<Car_SpecialAbility>().HasKey(x => new
		{
			x.CarId,
			x.SpecialAbilityId
		});

		modelBuilder.Entity<Car_SpecialAbility>()
			.HasOne(x => x.SpecialAbility)
			.WithMany(y => y.Cars_SpecialAbilities)
			.HasForeignKey(x => x.SpecialAbilityId);

		modelBuilder.Entity<Car_SpecialAbility>()
			.HasOne(x => x.Car)
			.WithMany(y => y.Cars_SpecialAbilities)
			.HasForeignKey(x => x.CarId);

		base.OnModelCreating(modelBuilder);
	}
}