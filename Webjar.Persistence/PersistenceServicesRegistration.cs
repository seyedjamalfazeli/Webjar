using Webjar.Application.Contracts.Persistence;
using Webjar.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webjar.Persistence;

namespace Webjar.Persistence
{
	public static class PersistenceServicesRegistration
	{
		public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<ProductDbContext>(options =>
			{
				options.UseSqlServer(configuration
					.GetConnectionString("WebjarTaskConnectionString"));
			});

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddScoped<IAccessoryRepository, AccessoryRepository>();
			services.AddScoped<IColorVariableRepository, ColorVariableRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ISizeVariableRepository, SizeVariableRepository>();

			return services;
		}
	}
}
