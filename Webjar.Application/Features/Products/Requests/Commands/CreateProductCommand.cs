using MediatR;
using Webjar.Application.DTOs.Product;
using Webjar.Application.Responses;

namespace Webjar.Application.Features.Products.Requests.Commands
{
	public class CreateProductCommand : IRequest<BaseCommandResponse>
	{
		public CreateProductDto ProductDto { get; set; } = null!;
	}
}
