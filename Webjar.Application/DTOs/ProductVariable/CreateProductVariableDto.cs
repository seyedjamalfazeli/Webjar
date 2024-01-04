
using Webjar.Application.DTOs.Common;

namespace Webjar.Application.DTOs.ProductVariable
{
	public class CreateProductVariableDto: BaseDto
	{
		public int ProductId { get; set; }
		public decimal Amount { get; set; }
		public float DollarValue { get; set; }
		public int Stock { get; set; }
		public int ColorVariableId { get; set; }
		public int SizeVariableId { get; set; }
		public decimal DiscountAmount { get; set; }
		public DateTime? DiscountExpireAt { get; set; }
		public List<int>? AccessoryIds { get; set; }
	}
}
