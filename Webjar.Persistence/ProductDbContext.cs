using Microsoft.EntityFrameworkCore;
using Webjar.Domain;
using Webjar.Domain.Common;

namespace Webjar.Persistence
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext(DbContextOptions<ProductDbContext> options)
		   : base(options)
		{

		}

		public DbSet<Accessory> Accessories { get; set; }
		public DbSet<ColorVariable> ColorVariables { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductVariable> ProductVariables { get; set; }
		public DbSet<ProductVariableAccessory> ProductVariableAccessories { get; set; }
		public DbSet<SizeVariable> SizeVariables { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
		}

		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
			foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
			{
				entry.Entity.LastModifiedDate = DateTime.Now;

				if (entry.State == EntityState.Added)
				{
					entry.Entity.DateCreated = DateTime.Now;
				}
			}


			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
			{
				entry.Entity.LastModifiedDate = DateTime.Now;

				if (entry.State == EntityState.Added)
				{
					entry.Entity.DateCreated = DateTime.Now;
				}
			}
			return base.SaveChanges();
		}
	}
}
