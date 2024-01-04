using Webjar.Application.DTOs.Product;
using Webjar.Domain;

namespace Webjar.Application.Contracts.Persistence
{
	public interface IProductRepository : IGenericRepository<Product>
	{
		Task<List<ProductDto>> GetProductWithDetails();
	}
}
