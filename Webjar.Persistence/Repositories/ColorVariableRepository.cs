using Webjar.Application.Contracts.Persistence;
using Webjar.Domain;

namespace Webjar.Persistence.Repositories
{
	public class ColorVariableRepository : GenericRepository<ColorVariable>, IColorVariableRepository
	{
		public ColorVariableRepository(ProductDbContext context) : base(context)
		{
		}
	}
}
