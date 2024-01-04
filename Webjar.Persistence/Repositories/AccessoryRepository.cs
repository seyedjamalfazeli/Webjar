using Webjar.Application.Contracts.Persistence;
using Webjar.Domain;

namespace Webjar.Persistence.Repositories
{
	public class AccessoryRepository : GenericRepository<Accessory>, IAccessoryRepository
	{
		public AccessoryRepository(ProductDbContext context) : base(context)
		{
		}
	}
}
