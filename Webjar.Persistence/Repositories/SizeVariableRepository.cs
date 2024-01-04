using Webjar.Application.Contracts.Persistence;
using Webjar.Domain;

namespace Webjar.Persistence.Repositories
{
	public class SizeVariableRepository : GenericRepository<SizeVariable>, ISizeVariableRepository
	{
		public SizeVariableRepository(ProductDbContext context) : base(context)
		{
		}
	}
}
