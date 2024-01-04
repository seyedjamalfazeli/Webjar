using Webjar.Application.DTOs.Common;
using Webjar.Application.DTOs.ProductVariable;

namespace Webjar.Application.DTOs.Product
{
	public class ProductDto : BaseDto , IProductDto
	{
		public string Title { get; set; } = null!;
		public string ImageUrl { get; set; } = null!;
		public decimal FinalPrice { get; set; }
		public List<ProductVariableDto> Variables { get; set; } = null!;
	}
}
