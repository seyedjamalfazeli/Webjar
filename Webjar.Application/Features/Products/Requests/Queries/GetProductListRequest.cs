
using MediatR;
using Webjar.Application.DTOs.Product;

namespace Webjar.Application.Features.Products.Requests.Queries
{
	public class GetProductListRequest : IRequest<List<ProductDto>>
	{
	}
}
