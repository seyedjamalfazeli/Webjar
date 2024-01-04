using AutoMapper;
using MediatR;
using Webjar.Application.Contracts.Persistence;
using Webjar.Application.DTOs.Product;
using Webjar.Application.Features.Products.Requests.Queries;

namespace Webjar.Application.Features.Products.Handlers.Queries
{
	public class GetProductListRequestHandler :
		IRequestHandler<GetProductListRequest, List<ProductDto>>
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.GetProductWithDetails();
			return products;
		}
	}
}
