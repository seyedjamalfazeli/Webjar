using Microsoft.AspNetCore.Http;
using Webjar.Application.DTOs.Common;
using Webjar.Application.DTOs.ProductVariable;

namespace Webjar.Application.DTOs.Product
{
	public class CreateProductDto : IProductDto
	{
		public string Title { get; set; } = null!;
		public IFormFile ImageFile { get; set; } = null!;
		public List<CreateProductVariableDto> Variables { get; set; } = null!;
	}
}
